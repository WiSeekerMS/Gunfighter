using Common.Extensions;
using Gameplay.ShootSystem;
using Gameplay.ShootSystem.Factories;
using Gameplay.ShootSystem.Models;
using Gameplay.ShootSystem.Presenters;
using Gameplay.ShotSystem.Presenters;
using Gameplay.ShotSystem.Signals;
using Zenject;

namespace Gameplay.ShotSystem.Installers
{
    public class ShotInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.InstallService<ShotPresenter>();
            Container.InstallService<MouseLookPresenter>();
            Container.InstallService<AimCameraPresenter>();
            Container.InstallService<BobbingPresenter>();
            
            Container.InstallModel<ShootModel>();
            Container.InstallModel<MouseLookModel>();
            Container.InstallModel<AimCameraModel>();
            Container.InstallModel<BobbingModel>();

            Container.DeclareSignal<ShotSignals.ReleaseBullet>();
            Container.DeclareSignal<ShotSignals.Shot>();
            Container.DeclareSignal<ShotSignals.Recoil>();
            Container.DeclareSignal<ShotSignals.Hit>();
            Container.DeclareSignal<ShotSignals.AimingStatus>();

            Container.InstallFactory<FlyingBullet, BulletFactory>();
        }
    }
}