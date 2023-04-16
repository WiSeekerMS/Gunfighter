using Gameplay.ShootSystem.Models;
using Gameplay.ShotSystem.Views;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.ShotSystem.Presenters
{
    public class BobbingPresenter : IInitializable
    {
        private readonly BobbingModel _bobbingModel;
        private readonly BobbingView _bobbingView;

        public BobbingPresenter(
            BobbingModel bobbingModel,
            BobbingView bobbingView)
        {
            _bobbingModel = bobbingModel;
            _bobbingView = bobbingView;
        }

        public void Initialize()
        {
            _bobbingView.Init();
            _bobbingModel.DefaultPosition = _bobbingView.DefaultPosition;
        }

        public void SetBobbingSmoothTime(float time)
        {
            _bobbingModel.BobbingSmoothTime = time;
        }

        public void BobbingDeltaShift(float delta)
        {
            _bobbingModel.BobbingDeltaShift = delta;
        }
        
        public void SetBobbingValue(bool value)
        {
            _bobbingModel.IsBobbing = value;
            if (!value) _bobbingView.ResetPosition();
        }

        private float GetRandomValue()
        {
            var r = Random.value;
            return r > 0.5f ? 1f : -1f;
        }

        public void OnUpdate()
        {
            if (!_bobbingModel.IsBobbing)
                return;
            
            var targetPosition = new Vector3
            {
                x = _bobbingModel.DefaultPosition.x + GetRandomValue() * _bobbingModel.BobbingDeltaShift,
                y = _bobbingModel.DefaultPosition.y + GetRandomValue() * _bobbingModel.BobbingDeltaShift,
                z = _bobbingModel.DefaultPosition.z
            };

            _bobbingView.UpdateSwingPosition(targetPosition, _bobbingModel.BobbingSmoothTime);
        }
    }
}