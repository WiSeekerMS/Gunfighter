using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Target.Configs
{
    public class BaseTargetConfig : ScriptableObject
    {
        [SerializeField] private float _damagePoints;
        [SerializeField] private List<GameObject> _targetPrefabs;
        
        public float DamagePoints => _damagePoints; 
        public List<GameObject> TargetPrefabs => _targetPrefabs;
    }
}