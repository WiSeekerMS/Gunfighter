using System.Collections.Generic;
using Common.Audio;
using Gameplay.ShotSystem.Signals;
using Gameplay.Target.Common.View;
using UnityEngine;
using Zenject;

namespace Gameplay.Target.Base.Managers
{
    public abstract class BaseTargetManager : MonoBehaviour
    {
        [SerializeField] protected List<AudioClip> _clips;
        [SerializeField] protected List<RandomTargetView> _targetViews;
        [Inject] protected SignalBus _signalBus;
        [Inject] protected AudioController _audioController;
        
        private void Awake()
        {
            _signalBus.Subscribe<ShotSignals.Hit>(OnHit);
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<ShotSignals.Hit>(OnHit);
        }

        protected abstract void OnHit(ShotSignals.Hit signal);
    }
}