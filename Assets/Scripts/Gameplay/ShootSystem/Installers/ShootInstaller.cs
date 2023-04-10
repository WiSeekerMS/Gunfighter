using Common.Extensions;
using Gameplay.ShootSystem.Factories;
using Gameplay.ShootSystem.Models;
using Gameplay.ShootSystem.Presenters;
using Gameplay.ShootSystem.Signals;
using Zenject;

namespace Gameplay.ShootSystem.Installers
{
    public class ShootInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.InstallService<ShootPresenter>();
            Container.InstallService<MouseLookPresenter>();
            Container.InstallService<AimCameraPresenter>();
            Container.InstallService<BobbingPresenter>();
            
            Container.InstallModel<ShootModel>();
            Container.InstallModel<MouseLookModel>();
            Container.InstallModel<AimCameraModel>();
            Container.InstallModel<BobbingModel>();

            Container.DeclareSignal<ShotSignals.Hit>();
            Container.DeclareSignal<ShotSignals.UpdateRotation>();
            Container.DeclareSignal<ShotSignals.UpdateAimCameraPosition>();
            Container.DeclareSignal<ShotSignals.UpdateAimCameraFieldOfView>();
            Container.DeclareSignal<ShotSignals.UpdateSwingPosition>();
            Container.DeclareSignal<ShotSignals.AimingStatus>();
            Container.DeclareSignal<ShotSignals.ResetSwingPosition>();
            
            Container.InstallFactory<FlyingBullet, BulletFactory>();
        }
    }
}