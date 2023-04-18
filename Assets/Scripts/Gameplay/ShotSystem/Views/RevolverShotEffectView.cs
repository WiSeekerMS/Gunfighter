using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Gameplay.ShotSystem.Presenters;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.ShotSystem.Views
{
    public class RevolverShotEffectView : MonoBehaviour
    {
        [SerializeField] private Transform _drumTransform;
        [SerializeField] private Transform _hammerTransform;
        [SerializeField] private ParticleSystem _effectPS;
        [SerializeField] private float _drumRotateSpeed;
        [SerializeField] private float _hammerRotateSpeed;
        [SerializeField] private float _effectTime;
        [SerializeField] private float _recoilRotateSpeed;
        [SerializeField] private float _recoilShifteSpeed;
        [SerializeField] private Vector3 _recoilEuler;
        [SerializeField] private Vector3 _recoilPosition;
        [Inject] private ShotPresenter _shotPresenter;
        private IDisposable _timerObservable;
        private Sequence _drumSequence;
        private Sequence _hammerSequence;
        private Sequence _recoilSequence;
        private float _drumRotateAngle;
        private float _hammerRotateAngle;
        private Vector3 _euler;
        private TimeSpan _effectDelay;
        private Vector3 _startPosition;
        
        private TweenerCore<Vector3, Vector3, VectorOptions> _recoilShiftTween;
        private TweenerCore<Quaternion, Vector3, QuaternionOptions> _recoilRotateTween;

        public event Action AnimationStop;

        private void Start()
        {
            _drumRotateAngle = 360f / 7;
            _hammerRotateAngle = 40f;
            _startPosition = transform.localPosition;
            _effectDelay = TimeSpan.FromSeconds(_effectTime);
        }

        public void OnShot()
        {
            CockRevolver(RotateDrum);
        }

        private void ReleaseFlash()
        {
            if (_effectPS.isPlaying)
                _effectPS.Stop();
            
            _timerObservable?.Dispose();
            _effectPS.Play();
            
            _timerObservable = Observable
                .Timer(_effectDelay)
                .Subscribe(_ =>
                {
                    _effectPS.Stop();
                    AnimationStop?.Invoke();
                });
        }

        private void RotateDrum()
        {
            _drumSequence?.Kill();
            _drumSequence = DOTween.Sequence();
            
            _euler += Vector3.back * _drumRotateAngle;
            if (_euler.z < -360f)
            {
                var z = _euler.z + 360f;
                _euler = Vector3.forward * z;
            }
            
            _drumSequence.Join(_drumTransform
                .DOLocalRotate(_euler, _drumRotateSpeed)
                .SetEase(Ease.Linear))
                .OnComplete(ReleaseBullet);
        }

        private void CockRevolver(Action action)
        {
            _hammerSequence?.Kill();
            _hammerSequence = DOTween.Sequence();

            var euler = Vector3.left * _hammerRotateAngle;
            _hammerSequence.Join(_hammerTransform
                .DOLocalRotate(euler, _hammerRotateSpeed)
                .SetEase(Ease.Linear))
                .OnComplete(() =>
                {
                    _hammerTransform.localEulerAngles = Vector3.zero;
                    action?.Invoke();
                });
        }

        public void StartRecoil()
        {
            if (_recoilSequence != null
                && _recoilSequence.active)
            {
                _recoilSequence?.Kill();
                transform.localEulerAngles = Vector3.zero;
                transform.localPosition = _startPosition;
            }
            
            _recoilSequence = DOTween.Sequence();
            _recoilSequence.Pause();

            transform.localEulerAngles = _recoilEuler;
            transform.localPosition += _recoilPosition;

            _recoilSequence.Join(transform
                .DOLocalMove(_startPosition, _recoilShifteSpeed)
                .SetEase(Ease.Linear));
            
            _recoilSequence.Join(transform
                .DOLocalRotate(Vector3.zero, _recoilRotateSpeed)
                .SetEase(Ease.Linear));
            
            _recoilSequence.Play();
        }

        private void ReleaseBullet()
        {
            if (_shotPresenter.BulletAmount <= 0)
            {
                AnimationStop?.Invoke();
                return;
            }
            
            ReleaseFlash();
        }
    }
}