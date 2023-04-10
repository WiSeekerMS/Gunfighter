using System.Collections.Generic;
using Common.Audio;
using Gameplay.ShootSystem.Signals;
using Gameplay.Target.GlassBottle.View;
using UnityEngine;
using Zenject;

namespace Gameplay.Target.GlassBottle
{
    public class GlassBottlePresenter : MonoBehaviour
    {
        [SerializeField] private List<GlassBottleView> _glassBottles;
        [SerializeField] private List<AudioClip> _clips;
        [Inject] private SignalBus _signalBus;
        [Inject] private AudioController _audioController;

        private void Awake()
        {
            _signalBus.Subscribe<ShotSignals.Hit>(OnHit);
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<ShotSignals.Hit>(OnHit);
        }
        private void OnHit(ShotSignals.Hit signal)
        {
            var component = signal.HitInfo.transform.GetComponent<GlassBottleView>();
            if (!component) return;

            var bottle = _glassBottles.Find(g => g == component);
            if (!bottle) return;

            var point = signal.HitInfo.point;
            bottle.OnHit(point);
            
            _audioController.PlayRandomAudioClip(_clips, point);
        }
    }
}