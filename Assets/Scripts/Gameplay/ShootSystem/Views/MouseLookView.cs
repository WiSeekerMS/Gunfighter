using Gameplay.ShootSystem.Signals;
using UnityEngine;
using Zenject;

namespace Gameplay.ShootSystem.Views
{
    public class MouseLookView : MonoBehaviour
    {
        [SerializeField] private Transform _bodyTransform;
        [Inject] private SignalBus _signalBus;

        private void Awake()
        {
            _signalBus.Subscribe<ShotSignals.UpdateRotation>(OnUpdateRotation);
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<ShotSignals.UpdateRotation>(OnUpdateRotation);
        }

        private void OnUpdateRotation(ShotSignals.UpdateRotation signal)
        {
            _bodyTransform.rotation = Quaternion.Euler(signal.Euler);
        }
    }
}