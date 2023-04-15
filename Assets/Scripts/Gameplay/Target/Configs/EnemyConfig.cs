using UnityEngine;

namespace Gameplay.Target.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private float _hp;
        [SerializeField] private float _moveSpeed;

        public float HP => _hp;
        public float MoveSpeed => _moveSpeed;
    }
}