using Gameplay.ShotSystem.Signals;
using Gameplay.Target.Base.Managers;
using Gameplay.Target.Common.View;

namespace Gameplay.Target.GlassBottle.Managers
{
    public class GlassBottlesManager : BaseTargetManager
    {
        protected override void OnHit(ShotSignals.Hit signal)
        {
            var component = signal.HitInfo.transform.GetComponent<RandomTargetView>();
            if (!component) return;

            var bottle = _targetViews.Find(g => g.Equals(component));
            if (!bottle) return;

            var point = signal.HitInfo.point;
            bottle.OnHit(point);
            
            _audioController.PlayRandomAudioClip(_clips, point);
        }
    }
}