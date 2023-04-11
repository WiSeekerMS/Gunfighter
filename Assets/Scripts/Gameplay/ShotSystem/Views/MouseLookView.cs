using UnityEngine;

namespace Gameplay.ShotSystem.Views
{
    public class MouseLookView : MonoBehaviour
    {
        [SerializeField] private Transform _bodyTransform;

        public void UpdateRotation(Vector3 euler)
        {
            _bodyTransform.localEulerAngles = euler;
        }
    }
}