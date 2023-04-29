using Common.Interfaces;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "SceneConfig", menuName = "Configs/Scene/SceneConfig")]
    public class SceneConfig : ScriptableObject, ISceneInfo
    {
        [SerializeField] private string _sceneName;
        public string SceneName => _sceneName;
    }
}