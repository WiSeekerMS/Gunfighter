using System;
using Gameplay.ShotSystem.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.ShotSystem.Views.Animatios
{
    public class BobbingAnimation : MonoBehaviour, IShootAnimation
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _xAxis;
        [SerializeField] private float _yAxis;
        private Vector3 _startPosition;
        private Vector3 _targetPosition;
        private bool _isPlay;
        
        public event Action CompleteEvent;
        public float DelayBeforePlay { get; set; }

        public void Prepare()
        {
            _startPosition = transform.localPosition;
        }

        private bool GetRandom()
        {
            return Random.value > 0.5f;
        }

        private void Update()
        {
            if (_isPlay)
            {
                var x = (GetRandom() ? _xAxis : -_xAxis) + _startPosition.x;
                var y = (GetRandom() ? _yAxis : -_yAxis) + _startPosition.y;
                _targetPosition = new Vector3(x, y, _startPosition.z);
            }
            else
            {
                _targetPosition = _startPosition;
            }
            
            var sightShiftSpeed = _speed * Time.deltaTime;
            transform.localPosition = Vector3.Lerp(transform.localPosition, 
                _targetPosition, sightShiftSpeed);
        }

        public void Play()
        {
            _isPlay = true;
        }

        public void Stop()
        {
            _isPlay = false;
        }
    }
}