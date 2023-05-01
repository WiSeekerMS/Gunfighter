using System.Collections;
using Gameplay.Target.Configs;
using TMPro;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Target
{
    public class DamagePointView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private RectTransform _rootRectTransform;
        private Vector3 _worldPoint;
        private TargetConfig _config;
        private float _fontSize;

        public void Init(Vector3 worldPoint, TargetConfig config)
        {
            _fontSize = _textMeshPro.fontSize;
            _textMeshPro.fontSize = 0f;
            
            _worldPoint = worldPoint + (Vector3)(Random.insideUnitCircle * config.SpreadRadius);
            _config = config;

            _textMeshPro.text = $"${_config.DamagePoints}";

            Observable
                .EveryUpdate()
                .Subscribe(_ => OnUpdate())
                .AddTo(this);

            Observable
                .FromCoroutine(AnimatedCor)
                .SelectMany(_ => AlphaFader(0f))
                .Subscribe(_ => OnTimerStopped())
                .AddTo(this);
        }

        private void OnUpdate()
        {
            var position = Camera.main.WorldToScreenPoint(_worldPoint);
            _rootRectTransform.position = position;
        }

        private IEnumerator AnimatedCor()
        {
            var t = 0f;
            while (t < _config.TimeToHide)
            {
                t += Time.deltaTime;
                _textMeshPro.fontSize = Mathf.Lerp(_textMeshPro.fontSize, _fontSize, t);
                yield return null;
            }
        }

        private IEnumerator AlphaFader(float value)
        {
            var t = 0f;
            var color = _textMeshPro.color;
            var targetColor = new Color(color.r, color.g, color.b, value);
            
            while (t < _config.AlphaFaderDuration)
            {
                t += Time.deltaTime;
                _textMeshPro.color = Color.Lerp(_textMeshPro.color, targetColor, t);
                yield return null;
            }
        }

        private void OnTimerStopped()
        {
            Destroy(gameObject);
        }
    }
}