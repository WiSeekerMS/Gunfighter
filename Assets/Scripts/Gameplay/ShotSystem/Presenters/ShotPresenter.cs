using System;
using Common;
using Common.Audio;
using Common.InputSystem.Signals;
using Gameplay.ShootSystem.Presenters;
using Gameplay.ShotSystem.Configs;
using Gameplay.ShotSystem.Models;
using Gameplay.ShotSystem.Signals;
using Gameplay.ShotSystem.Views;
using UI;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.ShotSystem.Presenters
{
    public class ShotPresenter : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly ShootModel _shootModel;
        private readonly ShotView _shotView;
        private readonly MouseLookPresenter _mouseLookPresenter;
        private readonly AimCameraPresenter _aimCameraPresenter;
        private readonly BobbingPresenter _bobbingPresenter;
        private readonly GameUIController _gameUIController;
        private readonly  AudioController _audioController;
        private IDisposable _updateObservable;
        private IDisposable _fixedUpdateObservable;
        private WeaponState _currentWeaponState;
        private bool _isBlockControl = true;
        private bool _isBlockShot;

        private const int LayerMask = 1 << Constants.TargetLayer | 1 << Constants.EnemyLayer;

        public bool IsAiming => _aimCameraPresenter.IsAiming;
        public int BulletAmount => _shootModel.BulletAmount;

        public ShotPresenter(
            SignalBus signalBus,
            ShootModel shootModel,
            ShotView shotView,
            MouseLookPresenter mouseLookPresenter,
            AimCameraPresenter aimCameraPresenter,
            BobbingPresenter bobbingPresenter,
            GameUIController gameUIController,
            AudioController audioController)
        {
            _signalBus = signalBus;
            _shootModel = shootModel;
            _shotView = shotView;
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
            _signalBus.Subscribe<InputSignals.ChangeWeapon>(OnWeaponChange);
            _signalBus.Subscribe<ShotSignals.AimingStatus>(SetBobbingValue);
            _signalBus.Subscribe<ShotSignals.Shot>(OnAfterReleaseBullet);
            _signalBus.Subscribe<ShotSignals.LoadGunComplete>(OnLoadGunComplete);
        }
        
        public void Prepare(WeaponConfig config)
        {
            _shootModel.WeaponConfig = config;
            _shootModel.BulletAmount = config.BulletAmount;

            _bobbingPresenter.SetBobbingSmoothTime(config.BobbingSmoothTime);
            _bobbingPresenter.BobbingDeltaShift(config.BobbingDeltaShift);
            
            WeaponChange(WeaponState.Right);
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
            _signalBus.Unsubscribe<InputSignals.ChangeWeapon>(OnWeaponChange);
            _signalBus.Unsubscribe<ShotSignals.Shot>(OnAfterReleaseBullet);
            _signalBus.Unsubscribe<ShotSignals.LoadGunComplete>(OnLoadGunComplete);
            _signalBus.Unsubscribe<ShotSignals.AimingStatus>(SetBobbingValue);
        }

        private void OnWeaponChange(InputSignals.ChangeWeapon signal)
        {
            WeaponChange(signal.State);
        }

        private void WeaponChange(WeaponState state)
        {
            _currentWeaponState = state;
            
            var view = _shotView.GetGunView(state);
            if (view == null) return;

            _aimCameraPresenter.SetAimingPosition(view.AimingPosition);
            _shootModel.MuzzleTransform = view.MuzzleTransform;
            
            _isBlockShot = true;
            _signalBus.Fire<ShotSignals.LoadGunStart>();
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
            //_bobbingPresenter.OnUpdate();
        }

        private void OnFixedUpdate()
        {
            var ray = new Ray(_shootModel.MuzzlePosition, _shootModel.MuzzleForward);
            _shootModel.IsHit = Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, LayerMask);
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

            _isBlockShot = true;
            var bulletAmount = _shootModel.BulletAmount;
            
            FireShot();
            
            _signalBus.Fire(new ShotSignals.ReleaseBullet(
                bulletAmount, _currentWeaponState));
        }

        private void FireShot()
        {
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

        private void OnAfterReleaseBullet()
        {
            _signalBus.Fire<ShotSignals.LoadGunStart>();
        }
        
        private void OnLoadGunComplete()
        {
            _isBlockShot = false;
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