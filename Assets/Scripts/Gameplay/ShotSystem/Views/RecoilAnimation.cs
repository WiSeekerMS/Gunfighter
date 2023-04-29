using System;
using Gameplay.ShotSystem.Interfaces;
using UnityEngine;

namespace Gameplay.ShotSystem.Views
{
    public class RecoilAnimation : MonoBehaviour, IShootAnimation
    {
        private Vector3 _startPosition;
        public event Action CompleteEvent;
        public float DelayBeforePlay { get; set; }
        
        public void Prepare()
        {
            _startPosition = transform.localPosition;
        }

        public void Play()
        {
            /*_animationObservable?.Dispose();
            _animationObservable = Observable
                .FromCoroutine(_ => AnimationCor())
                .Subscribe(_ => ResetRecoilPosition())
                .AddTo(this);*/
            
            CompleteEvent?.Invoke();
        }
        
        private void ResetRecoilPosition()
        {
            /*transform.localEulerAngles = Vector3.zero;
            transform.localPosition = _startPosition;*/
        }

        public void Stop()
        {
        }
    }
}