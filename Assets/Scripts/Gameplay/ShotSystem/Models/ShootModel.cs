using Gameplay.ShotSystem.Configs;
using UnityEngine;

namespace Gameplay.ShotSystem.Models
{
    public class ShootModel
    {
        public bool IsHit { get; set; }
        public int BulletAmount { get; set; }
        public WeaponConfig WeaponConfig { get; set; }
        public RaycastHit HitInfo { get; set; }
        public Transform MuzzleTransform { get; set; }
        
        public Vector3 MuzzlePosition => MuzzleTransform != null 
            ? MuzzleTransform.position 
            : Vector3.zero;

        public Vector3 MuzzleForward => MuzzleTransform != null
            ? MuzzleTransform.forward
            : Vector3.zero;
    }
}