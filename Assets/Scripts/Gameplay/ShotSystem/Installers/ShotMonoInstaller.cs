using Common.Extensions;
using Gameplay.ShootSystem.Views;
using Gameplay.ShotSystem.Views;
using UnityEngine;
using Zenject;

namespace Gameplay.ShotSystem.Installers
{
    public class ShotMonoInstaller : MonoInstaller
    {
        [SerializeField] private AimCameraView _aimCameraView;
        [SerializeField] private MouseLookView _mouseLookView;
        [SerializeField] private BobbingView _bobbingView;
        
        public override void InstallBindings()
        {
            Container.InstallRegistry(_aimCameraView);
            Container.InstallRegistry(_mouseLookView);
            Container.InstallRegistry(_bobbingView);
        }
    }
}