using UnityEngine;

namespace Common.Cheats.Configs
{
    [CreateAssetMenu(fileName = "CheatsConfig", menuName = "Configs/CheatsConfig")]
    public class CheatsConfig : ScriptableObject
    {
        [SerializeField] private bool _isExpendAmmo;

        public bool IsExpendAmmo => _isExpendAmmo;
    }
}