using Common.Cheats.Controllers;
using Common.Extensions;
using Zenject;

namespace Common.Cheats.Installers
{
    public class CheatsInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.InstallService<CheatsController>();
        }
    }
}