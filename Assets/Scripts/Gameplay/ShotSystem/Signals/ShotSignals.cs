using Common;
using UnityEngine;

namespace Gameplay.ShotSystem.Signals
{
    public static class ShotSignals
    {
        public sealed class ReleaseBullet
        {
            public WeaponState State { get; }

            public ReleaseBullet(WeaponState state)
            {
                State = state;
            }
        }
        
        public sealed class LoadGunStart
        {
        }
        
        public sealed class LoadGunComplete
        {
        }
        
        public sealed class Shot
        {
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