using Common.Audio;
using Common.Extensions;
using UI;
using UnityEngine;
using Zenject;

namespace Scenes.Installers
{
    public class ExampleMonoInstaller : MonoInstaller
    {
        [SerializeField] private SettingsPanel _settingsPanel;
        [SerializeField] private GameUIController _gameUIController;
        [SerializeField] private AudioController _audioController;

        public override void InstallBindings()
        {
            Container.InstallRegistry(_settingsPanel);
            Container.InstallRegistry(_gameUIController);
            Container.InstallRegistry(_audioController);
        }
    }
}