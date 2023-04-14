using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Gameplay.ShotSystem.Views
{
    [RequireComponent(typeof(Light))]
    public class LightFlickerView : MonoBehaviour
    {
        [SerializeField] private float _time = 0.05f;
        [SerializeField] private bool _isEnableOnStart;
        private IDisposable _flickerObservable;
        private Light _light;
        private float _timer;

        private void Awake()
        {
            _light = GetComponent<Light>();
            enabled = _isEnableOnStart;
        }

        private void OnEnable()
        {
            _flickerObservable = Observable
                .FromCoroutine(Flicker)
                .Subscribe();
        }

        private void OnDisable()
        {
            _flickerObservable?.Dispose();
        }

        private IEnumerator Flicker()
        {
            _light.enabled = !_light.enabled;
            
            do
            {
                _timer -= Time.deltaTime;
                yield return null;
            }
            while(_timer > 0f);
            _timer = _time;
        }
    }
}