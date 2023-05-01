using System;
using Common;
using Gameplay.ShotSystem.Presenters;
using Gameplay.ShotSystem.Signals;
using Gameplay.ShotSystem.Views.Animatios;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.ShotSystem.Views
{
    public class GunView : MonoBehaviour
    {
        [SerializeField] private WeaponState _weaponState;
        [SerializeField] private Transform _muzzleTransform;
        [SerializeField] private Vector3 _aimingPosition;
        [SerializeField] private Transform _hammerTransform;
        [SerializeField] private LoadGunAnimation _loadGunAnimation;
        [SerializeField] private RecoilAnimation _recoilAnimation;
        [SerializeField] private FlashAnimation _flashAnimation;
        [SerializeField] private BobbingAnimation _bobbingAnimation;
        [SerializeField] private float _bobbingDelay;
        
        [Inject] private SignalBus _signalBus;
        [Inject] private ShotPresenter _shotPresenter;
        
        private IDisposable _timerObservable;
        private TimeSpan _timeSpan;

        public WeaponState WeaponState => _weaponState;
        public Transform MuzzleTransform => _muzzleTransform;
        public Vector3 AimingPosition => _aimingPosition;
        
        private void Awake()
        {
            _signalBus.Subscribe<ShotSignals.LoadGunStart>(OnLoadGun);
            _signalBus.Subscribe<ShotSignals.ReleaseBullet>(OnShot);

            _loadGunAnimation.CompleteEvent += OnStopLoadGunAnimation;
            _recoilAnimation.CompleteEvent += OnStopReleaseAnimation;

            _bobbingAnimation.Prepare();
            _loadGunAnimation.Prepare();
            _recoilAnimation.Prepare();
            _flashAnimation.Prepare();
        }

        private void Start()
        {
            _timeSpan = TimeSpan.FromSeconds(_bobbingDelay);
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<ShotSignals.LoadGunStart>(OnLoadGun);
            _signalBus.Unsubscribe<ShotSignals.ReleaseBullet>(OnShot);

            _loadGunAnimation.CompleteEvent -= OnStopLoadGunAnimation;
            _recoilAnimation.CompleteEvent -= OnStopReleaseAnimation;
        }

        private void OnLoadGun(ShotSignals.LoadGunStart signal)
        {
            _loadGunAnimation.Play();
        }
        
        private void OnShot(ShotSignals.ReleaseBullet signal)
        {
            if (signal.State != WeaponState.Both 
                && signal.State != _weaponState) 
                return;

            ReleaseBullet(signal.BulletAmount);
        }
        
        private void ReleaseBullet(int bulletAmount)
        {
            _hammerTransform.localEulerAngles = Vector3.zero;
            
            if (bulletAmount <= 0)
            {
                OnStopReleaseAnimation();
                return;
            }
            
            _flashAnimation.Play();
            _recoilAnimation.Play();

            if (!_shotPresenter.IsAiming)
            {
                return;
            }
            
            _bobbingAnimation.Play();
            _timerObservable?.Dispose();
            
            _timerObservable = Observable
                .Timer(_timeSpan)
                .Subscribe(_ => _bobbingAnimation.Stop());
        }

        private void OnStopLoadGunAnimation()
        {
            _signalBus.Fire<ShotSignals.LoadGunComplete>();
        }

        private void OnStopReleaseAnimation()
        {
            _signalBus.Fire<ShotSignals.Shot>();
        }
    }
}