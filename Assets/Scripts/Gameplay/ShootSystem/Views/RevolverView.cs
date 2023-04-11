using UnityEngine;

namespace Gameplay.ShootSystem.Views
{
    public class RevolverView : MonoBehaviour
    {
        [SerializeField] private Transform _drumTransform;
        [SerializeField] private float _rotateAngle;
        private Vector3 _euler;

        public void RotateDrum()
        {
            _euler += Vector3.forward * _rotateAngle;
            _drumTransform.localRotation = Quaternion.Euler(_euler);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                RotateDrum();
            }
        }
    }
}