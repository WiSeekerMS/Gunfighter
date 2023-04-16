using System;
using DG.Tweening;
using Gameplay.ShootSystem.Presenters;
using Gameplay.ShotSystem.Presenters;
using Gameplay.ShotSystem.Signals;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.ShotSystem.Views
{
    public class RevolverShotEffectView : MonoBehaviour
    {
        [SerializeField] private Transform _drumTransform;
        [SerializeField] private ParticleSystem _effectPS;
        [SerializeField] private float _drumRotateSpeed;
        [SerializeField] private float _time;
        [Inject] private ShotPresenter _shotPresenter;
        private IDisposable _timerObservable;
        private Sequence _sequence;
        private float _rotateAngle;
        private Vector3 _euler;

        private void Start()
        {
            _rotateAngle = 360f / 7;
        }

        public void OnShot()
        {
            if (_shotPresenter.BulletAmount > 0)
            {
                ReleaseFlash();
            }
            
            RotateDrum();
        }

        private void ReleaseFlash()
        {
            _timerObservable?.Dispose();
            _effectPS.Play();
            
            _timerObservable = Observable
                .Timer(TimeSpan.FromSeconds(_time))
                .Subscribe(_ => { _effectPS.Stop(); });
        }

        private void RotateDrum()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            
            _euler += Vector3.back * _rotateAngle;
            if (_euler.z < -360f)
            {
                var z = _euler.z + 360f;
                _euler = Vector3.forward * z;
            }
            
            _sequence.Join(_drumTransform
                .DOLocalRotate(_euler, _drumRotateSpeed)
                .SetEase(Ease.Linear));
        }
    }
}