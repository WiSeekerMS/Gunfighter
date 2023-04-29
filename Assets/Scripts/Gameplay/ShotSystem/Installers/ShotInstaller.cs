using Common.Extensions;
using Gameplay.ShootSystem.Models;
using Gameplay.ShootSystem.Presenters;
using Gameplay.ShotSystem.Models;
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
            Container.DeclareSignal<ShotSignals.LoadGunStart>();
            Container.DeclareSignal<ShotSignals.LoadGunComplete>();
            Container.DeclareSignal<ShotSignals.Shot>();
            Container.DeclareSignal<ShotSignals.Hit>();
            Container.DeclareSignal<ShotSignals.AimingStatus>();
        }
    }
}