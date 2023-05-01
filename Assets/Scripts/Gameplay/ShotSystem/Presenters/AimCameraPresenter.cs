using Configs;
using Gameplay.ShootSystem.Models;
using Gameplay.ShotSystem.Signals;
using Gameplay.ShotSystem.Views;
using UnityEngine;
using Zenject;

namespace Gameplay.ShotSystem.Presenters
{
    public class AimCameraPresenter : IInitializable
    {
        private readonly AimCameraModel _aimCameraModel;
        private readonly PlayerConfig _playerConfig;
        private readonly SignalBus _signalBus;
        private readonly AimCameraView _aimCameraView;

        public bool IsAiming => _aimCameraModel.IsAim;
        
        public AimCameraPresenter(
            SignalBus signalBus,
            AimCameraModel aimCameraModel,
            AimCameraView aimCameraView,
            PlayerConfig playerConfig)
        {
            _signalBus = signalBus;
            _aimCameraModel = aimCameraModel;
            _aimCameraView = aimCameraView;
            _playerConfig = playerConfig;
        }
        
        public void Initialize()
        {
            _aimCameraView.Init();
            _aimCameraModel.OriginalPosition = _aimCameraView.OriginalPosition;
        }

        public void SetAimingPosition(Vector3 position)
        {
            _aimCameraModel.AimingPosition = position;
        }

        public void OnUpdate()
        {
            var cameraPosition = _aimCameraModel.IsAim 
                ? _aimCameraModel.AimingPosition 
                : _aimCameraModel.OriginalPosition;
            
            _aimCameraView.UpdateWeaponPosition(cameraPosition);
            
            var fieldOfView = _aimCameraModel.IsAim 
                ? _playerConfig.FieldOfViewAiming 
                : _playerConfig.FieldOfView;
            
            _aimCameraView.UpdateCameraFieldOfView(fieldOfView);
            _signalBus.Fire(new ShotSignals.AimingStatus(_aimCameraModel.IsAim));
        }
    }
}