using System;
using DG.Tweening;
using Gameplay.ShotSystem.Interfaces;
using UniRx;
using UnityEngine;

namespace Gameplay.ShotSystem.Views.Animatios
{
    public class LoadGunAnimation : MonoBehaviour, IShootAnimation
    {
        [SerializeField] private Transform _drumTransform;
        [SerializeField] private Transform _hammerTransform;
        [SerializeField] private float _drumRotateSpeed;
        private Sequence _loadGunSequence;
        private IDisposable _delayObservable;
        private int _tweensCounter;
        private float _drumRotateAngle;
        private float _hammerRotateAngle;
        private Vector3 _drumEuler;

        private const int TweensCount = 2;
        public event Action CompleteEvent;
        public float DelayBeforePlay { get; set; } = 0.3f;
        
        public void Prepare()
        {
            _loadGunSequence = DOTween.Sequence();
            _drumRotateAngle = 360f / 7;
            _hammerRotateAngle = 32f;
        } 
        
        public void Play()
        {
            _delayObservable?.Dispose();
            if (DelayBeforePlay <= 0f)
            {
                LoadGun();
                return;
            }
            
            _delayObservable = Observable
                .Timer(TimeSpan.FromSeconds(DelayBeforePlay))
                .Subscribe(_ => LoadGun())
                .AddTo(this);
        }
        
        private void OnCompleteLoadGunTween()
        {
            if (++_tweensCounter != TweensCount) 
                return;

            Complete();
        }

       private void LoadGun()
        {
            if (_loadGunSequence.active)
            {
                _loadGunSequence.Kill();
            }
            
            var clockEuler = Vector3.left * _hammerRotateAngle;
            _drumEuler += Vector3.back * _drumRotateAngle;
            if (_drumEuler.z < -360f)
            {
                _drumEuler.z += 360f;
            }

            _loadGunSequence
                .Append(_drumTransform
                    .DOLocalRotate(_drumEuler, _drumRotateSpeed)
                    .SetEase(Ease.Linear)
                    .OnComplete(OnCompleteLoadGunTween))
                .Join(_hammerTransform
                    .DOLocalRotate(clockEuler, _drumRotateSpeed)
                    .SetEase(Ease.Linear)
                    .OnComplete(OnCompleteLoadGunTween));
        }

       private void Complete()
       {
           _tweensCounter = 0;
           CompleteEvent?.Invoke();
       }

        public void Stop()
        {
            if (_loadGunSequence.active)
                _loadGunSequence.Kill();
            
            _tweensCounter = 0;
        }
    }
}