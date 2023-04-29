using System;
using Gameplay.ShotSystem.Presenters;
using UnityEngine;
using Zenject;

namespace Gameplay.ShotSystem.Views
{
    public class RevolverShotEffectView : MonoBehaviour
    {
        [SerializeField] private Transform _hammerTransform;
        [SerializeField] private LoadGunAnimation _loadGunAnimation;
        [SerializeField] private RecoilAnimation _recoilAnimation;
        [SerializeField] private FlashAnimation _flashAnimation;
        [Inject] private ShotPresenter _shotPresenter;

        public event Action LoadGunAnimationStop;
        public event Action ReleaseAnimationStop;

        private void Awake()
        {
            _loadGunAnimation.CompleteEvent += OnLoadGunComplete;
            _recoilAnimation.CompleteEvent += OnRecoilComplete;

            _loadGunAnimation.Prepare();
            _recoilAnimation.Prepare();
            _flashAnimation.Prepare();
        }

        private void OnDestroy()
        {
            _loadGunAnimation.CompleteEvent -= OnLoadGunComplete;
            _recoilAnimation.CompleteEvent -= OnRecoilComplete;
        }
        
        public void OnLoadGun()
        {
            _loadGunAnimation.Play();
        }
        
        private void OnLoadGunComplete()
        {
            LoadGunAnimationStop?.Invoke();
        }
        
        private void OnRecoilComplete()
        {
            ReleaseAnimationStop?.Invoke();
        }

        public void ReleaseBullet()
        {
            _hammerTransform.localEulerAngles = Vector3.zero;
            
            if (_shotPresenter.BulletAmount <= 0)
            {
                ReleaseAnimationStop?.Invoke();
                return;
            }

            _flashAnimation.Play();
            _recoilAnimation.Play();
        }
    }
}