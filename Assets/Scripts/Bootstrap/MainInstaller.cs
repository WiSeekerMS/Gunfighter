using Common.InputSystem.Installers;
using Gameplay.ShotSystem.Installers;
using Zenject;

namespace Bootstrap
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.Install<InputInstaller>();
            Container.Install<ShotInstaller>();
        }
    }
}