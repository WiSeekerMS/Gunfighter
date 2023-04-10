using System;
using UnityEngine;

namespace Gameplay.ShootSystem.Views
{
    public class RevolverView : MonoBehaviour
    {
        [SerializeField] private Transform _drumTransform;
        [SerializeField] private float _rotateAngle;

        public void RotateDrum()
        {
            _drumTransform.rotation *= Quaternion.Euler(Vector3.forward * _rotateAngle);
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