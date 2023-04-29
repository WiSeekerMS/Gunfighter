using Common;
using Gameplay.ShotSystem.Signals;
using UnityEngine;
using Zenject;

namespace Gameplay.ShotSystem.Views
{
    public class GunView : MonoBehaviour
    {
        [SerializeField] private WeaponState _weaponState;
        [SerializeField] private RevolverShotEffectView _shotEffectView;
        [SerializeField] private BobbingView _bobbingView;
        [SerializeField] private Transform _muzzleTransform;
        [SerializeField] private Vector3 _aimingPosition;
        [Inject] private SignalBus _signalBus;

        public WeaponState WeaponState => _weaponState;
        public Transform MuzzleTransform => _muzzleTransform;
        public Vector3 AimingPosition => _aimingPosition;
        
        private void Awake()
        {
            _signalBus.Subscribe<ShotSignals.LoadGunStart>(OnLoadGun);
            _signalBus.Subscribe<ShotSignals.ReleaseBullet>(OnShot);
            _shotEffectView.LoadGunAnimationStop += OnStopLoadGunAnimation;
            _shotEffectView.ReleaseAnimationStop += OnStopReleaseAnimation;
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<ShotSignals.LoadGunStart>(OnLoadGun);
            _signalBus.Unsubscribe<ShotSignals.ReleaseBullet>(OnShot);
            _shotEffectView.LoadGunAnimationStop -= OnStopLoadGunAnimation;
            _shotEffectView.ReleaseAnimationStop -= OnStopReleaseAnimation;
        }

        private void OnLoadGun(ShotSignals.LoadGunStart signal)
        {
            _shotEffectView.OnLoadGun();
        }

        private void OnShot(ShotSignals.ReleaseBullet signal)
        {
            if (signal.State == WeaponState.Both
                || signal.State == _weaponState)
            {
                _shotEffectView.ReleaseBullet();
            }
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