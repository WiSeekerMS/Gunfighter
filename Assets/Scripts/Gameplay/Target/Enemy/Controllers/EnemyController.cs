using System;
using Common;
using Gameplay.ShotSystem.Signals;
using Gameplay.Target.Enemy.View;
using Zenject;

namespace Gameplay.Target.Enemy.Controllers
{
    public class EnemyController : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;

        public EnemyController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ShotSignals.Hit>(OnHit);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ShotSignals.Hit>(OnHit);
        }

        private void OnHit(ShotSignals.Hit signal)
        {
            var obj = signal.HitInfo.transform.gameObject;
            if (obj.layer != Constants.EnemyLayer) return;

            var component = obj.GetComponentInParent<EnemyView>();
            if (!component) return;
            
            component.SetDamage(10f);
        }
    }
}