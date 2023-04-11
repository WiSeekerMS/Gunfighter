using Configs;
using Gameplay.ShootSystem.Models;
using Gameplay.ShotSystem.Signals;
using Gameplay.ShotSystem.Views;
using Zenject;

namespace Gameplay.ShotSystem.Presenters
{
    public class AimCameraPresenter : IInitializable
    {
        private readonly AimCameraModel _aimCameraModel;
        private readonly PlayerConfig _playerConfig;
        private readonly SignalBus _signalBus;
        private readonly AimCameraView _aimCameraView;

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
            _aimCameraModel.AimingPosition = _aimCameraView.AimingPosition;
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