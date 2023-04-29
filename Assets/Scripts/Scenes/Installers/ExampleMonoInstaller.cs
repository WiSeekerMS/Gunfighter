using Common.Audio;
using Common.Extensions;
using Gameplay.ShotSystem.Installers;
using Gameplay.Target.Installers;
using UI;
using UnityEngine;
using Zenject;

namespace Scenes.Installers
{
    public class ExampleMonoInstaller : MonoInstaller
    {
        [SerializeField] private GameUIController _gameUIController;
        [SerializeField] private AudioController _audioController;

        public override void InstallBindings()
        {
            Container.Install<ShotInstaller>();
            Container.Install<TargetInstaller>();

            Container.InstallRegistry(_gameUIController);
            Container.InstallRegistry(_audioController);
        }
    }
}