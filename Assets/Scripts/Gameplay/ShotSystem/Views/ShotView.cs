using System.Collections.Generic;
using Common;
using UnityEngine;

namespace Gameplay.ShotSystem.Views
{
    public class ShotView : MonoBehaviour
    {
        [SerializeField] private List<GunView> _gunViews;

        public GunView GetGunView(WeaponState state)
        {
            return _gunViews.Find(v => v.WeaponState == state);
        }
    }
}