using Common;
using UnityEngine;
using Zenject;

namespace Bootstrap
{
    public class Bootstrapper : MonoBehaviour
    {
        [Inject] private SceneLoaderService _sceneLoaderService;
        
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            //_sceneLoaderService.LoadScene(_mainMenuSceneConfig);
        }
    }
}