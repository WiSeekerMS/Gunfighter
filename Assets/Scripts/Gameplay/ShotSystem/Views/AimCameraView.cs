using Configs;
using UnityEngine;
using Zenject;

namespace Gameplay.ShotSystem.Views
{
    public class AimCameraView : MonoBehaviour
    {
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private Transform _weaponParent;
        [Inject] private PlayerConfig _playerConfig;
        private Vector3 _originalPosition;

        public Vector3 OriginalPosition => _originalPosition;

        public void Init()
        {
            _originalPosition = _weaponParent.localPosition;
        }

        public void UpdateWeaponPosition(Vector3 position)
        {
            _weaponParent.localPosition = Vector3.Lerp(_weaponParent.localPosition, 
                position, _playerConfig.AimingSpeed * Time.deltaTime);
        }

        public void UpdateCameraFieldOfView(float fieldOfView)
        {
            _playerCamera.fieldOfView = Mathf.Lerp(_playerCamera.fieldOfView, 
                fieldOfView, _playerConfig.ViewFieldShiftSpeed * Time.deltaTime);
        }
    }
}