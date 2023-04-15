using Common.Extensions;
using Gameplay.Target.Enemy.Controllers;
using Zenject;

namespace Gameplay.Target.Installers
{
    public class TargetInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.InstallService<EnemyController>();
        }
    }
}