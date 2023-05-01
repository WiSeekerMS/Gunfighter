using System;
using DG.Tweening;
using Gameplay.ShotSystem.Interfaces;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.ShotSystem.Views.Animatios
{
    public class RecoilAnimation : MonoBehaviour, IShootAnimation
    {
        [SerializeField] private Vector2 _rotateAxisX;
        [SerializeField] private Vector2 _rotateAxisY;
        [SerializeField] private Vector2 _rotateAxisZ;
        [SerializeField] private Vector3 _recoilShiftPosition;
        [SerializeField] private Transform _gunTransform;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _revertSpeed;
        [SerializeField] private float _delayAfterRevert;
        private Vector3 _recoilPosition;
        private Vector3 _startPosition;
        private Sequence _recoilSequence;
        private int _tweensCounter;
        private TimeSpan _delayTime;
        private IDisposable _timerObservable;

        private const int TweensCount = 2;

        public event Action CompleteEvent;
        public float DelayBeforePlay { get; set; }
        
        public void Prepare()
        {
            _startPosition = transform.localPosition;
            _recoilPosition = _startPosition + _recoilShiftPosition;
            _recoilSequence = DOTween.Sequence();
            _delayTime = TimeSpan.FromSeconds(_delayAfterRevert);
        }

        public void Play()
        {
            StartRecoil();
        }
        
        private void OnCompleteRecoilTween()
        {
            if (++_tweensCounter != TweensCount) 
                return;

            RecoilComplete();
        }

        private void RecoilComplete()
        {
            _tweensCounter = 0;
            _timerObservable?.Dispose();
            
            _timerObservable = Observable
                .Timer(_delayTime)
                .Subscribe(_ => RevertRotationAndPosition());
        }

        private void StartRecoil()
        {
            if (_recoilSequence.active)
                _recoilSequence.Kill();
            
            var x = Random.Range(_rotateAxisX.x, _rotateAxisX.y);
            var y = Random.Range(_rotateAxisY.x, _rotateAxisY.y);
            var z = Random.Range(_rotateAxisZ.x, _rotateAxisZ.y);
            var rotateEuler = new Vector3(x, y, z);

            _recoilSequence
                .Append(_gunTransform
                    .DOLocalRotate(rotateEuler, _rotateSpeed)
                    .SetEase(Ease.Linear)
                    .OnComplete(OnCompleteRecoilTween))
                .Join(_gunTransform.
                    DOLocalMove(_recoilPosition, _rotateSpeed)
                    .SetEase(Ease.Linear)
                    .OnComplete(OnCompleteRecoilTween));
        }
        
        private void OnCompleteRevertTween()
        {
            if (++_tweensCounter != TweensCount) 
                return;

            Complete();
        }

        private void RevertRotationAndPosition()
        {
            if (_recoilSequence.active)
                _recoilSequence.Kill();

            var rotateEuler = Vector3.zero;
            var movePosition = _startPosition;
            
            _recoilSequence
                .Append(_gunTransform
                    .DOLocalRotate(rotateEuler, _revertSpeed)
                    .SetEase(Ease.Linear)
                    .OnComplete(OnCompleteRevertTween))
                .Join(_gunTransform.
                    DOLocalMove(movePosition, _revertSpeed)
                    .SetEase(Ease.Linear)
                    .OnComplete(OnCompleteRevertTween));
        }
        
        private void Complete()
        {
            _recoilSequence.Kill();
            _tweensCounter = 0;
            
            CompleteEvent?.Invoke();
        }
        

        public void Stop()
        {
            if (_recoilSequence.active)
                _recoilSequence.Kill();
            
            _timerObservable?.Dispose();
            _tweensCounter = 0;
        }
    }
}