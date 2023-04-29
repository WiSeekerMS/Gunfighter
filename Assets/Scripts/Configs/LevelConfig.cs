using Common.Interfaces;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/Scene/LevelConfig")]
    public class LevelConfig : ScriptableObject, ISceneInfo
    {
        [SerializeField] private string _sceneName;
        [SerializeField] private int _levelIndex;
        [SerializeField] private float _pointsToComplete;
        [SerializeField] private float _distanceToTarget;

        public string SceneName => _sceneName;
        public int LevelIndex => _levelIndex;
        public float PointsToComplete => _pointsToComplete;
        public float DistanceToTarget => _distanceToTarget;
    }
}