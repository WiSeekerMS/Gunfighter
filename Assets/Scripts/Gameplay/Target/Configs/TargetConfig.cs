using UnityEngine;

namespace Gameplay.Target.Configs
{
    [CreateAssetMenu(fileName = "TargetConfig", menuName = "Configs/TargetConfig")]
    public class TargetConfig : ScriptableObject
    {
        [SerializeField] private float _damagePoints;
        [SerializeField] private float _timeToHide;
        [SerializeField] private float _spreadRadius;
        [SerializeField] private float _alphaFaderDuration;

        public float DamagePoints => _damagePoints; 
        public float TimeToHide => _timeToHide;
        public float SpreadRadius => _spreadRadius;
        public float AlphaFaderDuration => _alphaFaderDuration;
    }
}