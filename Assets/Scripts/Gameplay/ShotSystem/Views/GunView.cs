using Common;
using Gameplay.ShotSystem.Signals;
using UnityEngine;
using Zenject;

namespace Gameplay.ShotSystem.Views
{
    public class GunView : MonoBehaviour
    {
        [SerializeField] private WeaponState _weaponState;
        [SerializeField] private RevolverShotEffectView _shotEffectView;
        [SerializeField] private BobbingView _bobbingView;
        [SerializeField] private Transform _muzzleTransform;
        [SerializeField] private Vector3 _aimingPosition;
        [Inject] private SignalBus _signalBus;

        public WeaponState WeaponState => _weaponState;
        public Transform MuzzleTransform => _muzzleTransform;
        public Vector3 AimingPosition => _aimingPosition;
        
        private void Awake()
        {
            _signalBus.Subscribe<ShotSignals.Shot>(OnShot);
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<ShotSignals.Shot>(OnShot);
        }

        private void OnShot(ShotSignals.Shot signal)
        {
            if (signal.State == WeaponState.Both
                || signal.State == _weaponState)
            {
                _shotEffectView.OnShot();
            }
        }
    }
}