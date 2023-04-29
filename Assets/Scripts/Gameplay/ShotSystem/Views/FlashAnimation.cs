using System;
using Gameplay.ShotSystem.Interfaces;
using UniRx;
using UnityEngine;

namespace Gameplay.ShotSystem.Views
{
    public class FlashAnimation : MonoBehaviour, IShootAnimation
    {
        [SerializeField] private ParticleSystem _effectPS;
        [SerializeField] private float _effectTime;
        private IDisposable _timerObservable;
        private TimeSpan _effectDelay;
        
        public event Action CompleteEvent;
        public float DelayBeforePlay { get; set; }
        
        public void Prepare()
        {
            _effectDelay = TimeSpan.FromSeconds(_effectTime);
        }

        public void Play()
        {
            if (_effectPS.isPlaying)
                _effectPS.Stop();
            
            _timerObservable?.Dispose();
            _effectPS.Play();
            
            _timerObservable = Observable
                .Timer(_effectDelay)
                .Subscribe(_ => { _effectPS.Stop(); })
                .AddTo(this);
        }

        public void Stop()
        {
        }
    }
}