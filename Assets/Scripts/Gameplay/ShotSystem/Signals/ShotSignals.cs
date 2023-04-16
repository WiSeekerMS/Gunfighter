using Common;
using UnityEngine;

namespace Gameplay.ShotSystem.Signals
{
    public static class ShotSignals
    {
        public sealed class Shot
        {
            public WeaponState State { get; }

            public Shot(WeaponState state)
            {
                State = state;
            }
        }
        
        public sealed class Hit
        {
            public RaycastHit HitInfo { get; }
            public Hit(RaycastHit hitInfo)
            {
                HitInfo = hitInfo;
            }
        }

        public sealed class AimingStatus
        {
            public bool IsAiming { get; }

            public AimingStatus(bool isAiming)
            {
                IsAiming = isAiming;
            }
        }
    }
}