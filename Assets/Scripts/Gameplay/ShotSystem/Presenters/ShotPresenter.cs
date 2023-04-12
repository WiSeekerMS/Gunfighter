using System;
using Common.Audio;
using Common.InputSystem.Signals;
using Gameplay.ShootSystem.Configs;
using Gameplay.ShootSystem.Models;
using Gameplay.ShotSystem.Presenters;
using Gameplay.ShotSystem.Signals;
using UI;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.ShootSystem.Presenters
{
    public class ShotPresenter : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly ShootModel _shootModel;
        private readonly MouseLookPresenter _mouseLookPresenter;
        private readonly AimCameraPresenter _aimCameraPresenter;
        private readonly BobbingPresenter _bobbingPresenter;
        private readonly GameUIController _gameUIController;
        private readonly  AudioController _audioController;
        private IDisposable _updateObservable;
        private IDisposable _fixedUpdateObservable;
        private bool _isBlockControl = true;
        private bool _isBlockShot;

        public int BulletAmount => _shootModel.BulletAmount;

        public ShotPresenter(
            SignalBus signalBus,
            ShootModel shootModel, 
            MouseLookPresenter mouseLookPresenter,
            AimCameraPresenter aimCameraPresenter,
            BobbingPresenter bobbingPresenter,
            GameUIController gameUIController,
            AudioController audioController)
        {
            _signalBus = signalBus;
            _shootModel = shootModel;
            _mouseLookPresenter = mouseLookPresenter;
            _aimCameraPresenter = aimCameraPresenter;
            _bobbingPresenter = bobbingPresenter;
            _gameUIController = gameUIController;
            _audioController = audioController;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<InputSignals.Shot>(OnReleaseBullet);
            _signalBus.Subscribe<InputSignals.Reload>(OnReload);
            _signalBus.Subscribe<ShotSignals.AimingStatus>(SetBobbingValue);
        }
        
        public void Prepare(WeaponConfig config)
        {
            _shootModel.WeaponConfig = config;
            _shootModel.BulletAmount = config.BulletAmount;
            _shootModel.BulletPrefab = config.BulletPrefab;
            
            _bobbingPresenter.SetBobbingSmoothTime(config.BobbingSmoothTime);
            _bobbingPresenter.BobbingDeltaShift(config.BobbingDeltaShift);
        }

        public void Enable()
        {
            _isBlockControl = false;
            
            _updateObservable = Observable
                .EveryUpdate()
                .Subscribe(_ => OnUpdate());
            
            _fixedUpdateObservable = Observable
                .EveryFixedUpdate()
                .Subscribe(_ => OnFixedUpdate());
        }

        public void Disable()
        {
            _isBlockControl = true;
            _updateObservable?.Dispose();
            _fixedUpdateObservable?.Dispose();
        }

        public void Dispose()
        {
            _updateObservable?.Dispose();
            _fixedUpdateObservable?.Dispose();
            _signalBus.Unsubscribe<InputSignals.Shot>(OnReleaseBullet);
            _signalBus.Unsubscribe<InputSignals.Reload>(OnReload);
            _signalBus.Unsubscribe<ShotSignals.AimingStatus>(SetBobbingValue);
        }

        public void SetMuzzleTransform(Transform transform)
        {
            _shootModel.MuzzleTransform = transform;
        }
        
        public void BlockPlayerControl()
        {
            Disable();
            _mouseLookPresenter.Disable();
        }
        
        public void UnlockPlayerControl()
        {
            Enable();
            _mouseLookPresenter.Enable();
        }
        
        public void ResetParams()
        {
            OnReload();
        }

        private void OnUpdate()
        {
            _mouseLookPresenter.OnUpdate();
            _aimCameraPresenter.OnUpdate();
            _bobbingPresenter.OnUpdate();
        }

        private void OnFixedUpdate()
        {
            var ray = new Ray(_shootModel.MuzzlePosition, _shootModel.MuzzleForward);
            _shootModel.IsHit = Physics.Raycast(ray, out var hitInfo, Mathf.Infinity);
            _shootModel.HitInfo = hitInfo;

            if (!_shootModel.IsHit) return;
            var forward = _shootModel.MuzzleForward * hitInfo.distance;
            Debug.DrawRay(ray.origin, forward, Color.blue);
        }

        private void OnReleaseBullet()
        {
            if (_isBlockControl 
                || _isBlockShot)
            {
                return;
            }
            
            _signalBus.Fire<ShotSignals.Shot>();
            
            if (_shootModel.BulletAmount <= 0)
            {
                var noAmoClips = _shootModel.WeaponConfig.NoAmoClips;
                _audioController.PlayRandomAudioClip(noAmoClips, Vector3.zero);
                return;
            }

            _shootModel.BulletAmount--;
            _gameUIController.HideLastBullet();
 
            var shotClips = _shootModel.WeaponConfig.ShotAudioClips;
            _audioController.PlayRandomAudioClip(shotClips, Vector3.zero);
 
            if (_shootModel.IsHit)
            {
                _signalBus.Fire(new ShotSignals.Hit(_shootModel.HitInfo));
            }
        }

        private void OnReload()
        {
            if (_shootModel.BulletAmount >= _shootModel.WeaponConfig.BulletAmount) 
                return;

            _isBlockShot = true;
            _audioController.PlayClip(
                _shootModel.WeaponConfig.RechargeClip, 
                Vector3.zero, 
                () =>
                {
                    _gameUIController.ShowAllBullets();
                    _shootModel.BulletAmount = _shootModel.WeaponConfig.BulletAmount;
                    _isBlockShot = false;
                });
        }

        private void SetBobbingValue(ShotSignals.AimingStatus signal)
        {
            _bobbingPresenter.SetBobbingValue(signal.IsAiming);
        }
    }
}