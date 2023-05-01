using Common.Extensions;
using UI.MainMenu.Controllers;
using Zenject;

namespace UI.MainMenu.Installers
{
    public class MainMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.InstallService<MainMenuController>();
        }
    }
}