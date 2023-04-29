using System;
using Common.Interfaces;
using UniRx;
using Zenject;

namespace Common
{
    public class SceneLoaderService
    {
        private readonly SignalBus _signalBus;
        private readonly ZenjectSceneLoader _zenjectSceneLoader;
        private IDisposable _loadingOperation;
        private ISceneInfo _nextScene;

        public SceneLoaderService(
            SignalBus signalBus, 
            ZenjectSceneLoader zenjectSceneLoader)
        {
            _signalBus = signalBus;
            _zenjectSceneLoader = zenjectSceneLoader;
        }
        
        public void LoadScene(ISceneInfo sceneInfo)
        {
            _nextScene = sceneInfo;
            LoadLevelAsync();
        }

        private void UnloadLevelAsync()
        {
        }

        private void LoadLevelAsync()
        {
            _loadingOperation?.Dispose();

            var loadingProgress = new Subject<float>();
            var progress = new Progress<float>(loadingProgress.OnNext);

            var loadingStream = _zenjectSceneLoader
                .LoadSceneAsync(_nextScene.SceneName)
                .AsAsyncOperationObservable(progress);

            /*_loadingOperation = loadingStream
                .DoOnCompleted()
                .DoOnError()
                .Subscribe();*/
        }
    }
}