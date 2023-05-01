using Common;
using Common.Cheats.Installers;
using Common.Extensions;
using Common.InputSystem.Installers;
using UI.MainMenu.Installers;
using Zenject;

namespace Bootstrap
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.InstallService<SceneLoaderService>();
            
            Container.Install<InputInstaller>();
            Container.Install<CheatsInstaller>();
            Container.Install<MainMenuInstaller>();
        }
    }
}