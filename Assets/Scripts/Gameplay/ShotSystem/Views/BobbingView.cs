using UnityEngine;

namespace Gameplay.ShotSystem.Views
{
    public class BobbingView : MonoBehaviour
    {
        private Vector3 _velocity = Vector3.zero;
        
        public Vector3 DefaultPosition { get; private set; }

        public void Init()
        {
            DefaultPosition = transform.localPosition;
        }

        public void ResetPosition()
        {
            transform.localPosition = DefaultPosition;
        }

        public void UpdateSwingPosition(Vector3 targetPosition, float sightShiftSpeed)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, 
                targetPosition, ref _velocity, sightShiftSpeed);
        }
    }
}