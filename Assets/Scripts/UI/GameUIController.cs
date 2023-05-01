using System.Collections.Generic;
using System.Linq;
using Configs;
using Gameplay.Target.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class GameUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreTMP;
        [SerializeField] private RectTransform _bulletContainer;
        [SerializeField] private RectTransform _damagePointsContainer;
        [SerializeField] private Color _hiddenBulletColor;
        private List<Image> _bulletList = new List<Image>();
        private MainConfig _mainConfig;
        private TargetConfig _targetConfig;
        private float _currentScore;

        [Inject]
        private void Constructor(
            MainConfig mainConfig, 
            TargetConfig targetConfig)
        {
            _mainConfig = mainConfig;
            _targetConfig = targetConfig;
        }
        
        public float CurrentScore => _currentScore;

        public void UpdateScore(float points)
        {
            _currentScore += points;
            _scoreTMP.text = _currentScore.ToString();
        }

        public void ResetScore()
        {
            _currentScore = 0f;
            _scoreTMP.text = _currentScore.ToString();
        }

        public void AddDamagePoint(Vector3 worldPoint)
        {
            var prefab = _mainConfig.DamagePointPrefab;
            var point = Instantiate(prefab, _damagePointsContainer);
            point.Init(worldPoint, _targetConfig);
        }
        
        public void SetBulletAmount(int count)
        {
            if (_bulletList.Any())
            {
                _bulletList.ForEach(i => Destroy(i.gameObject));
            }
            
            for (int i = 0; i < count; i++)
            {
                var icon = Instantiate(_mainConfig.BulletIconPrefab, _bulletContainer);
                _bulletList.Add(icon);
            }
        }

        public void HideLastBullet()
        {
            var lastIcon = _bulletList.LastOrDefault(i => i.color == Color.white);
            if (lastIcon) lastIcon.color = _hiddenBulletColor;
        }

        public void ShowAllBullets()
        {
            _bulletList.ForEach(i => i.color = Color.white);
        }
    }
}