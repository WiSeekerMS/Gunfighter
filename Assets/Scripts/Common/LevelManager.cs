﻿using System;
using System.Collections.Generic;
using System.Linq;
using Configs;
using Gameplay.ShootSystem.Configs;
using Gameplay.ShootSystem.Presenters;
using Gameplay.ShootSystem.Signals;
using UI;
using UniRx;
using UnityEngine;
using Zenject;

namespace Common
{
    public class LevelManager : MonoBehaviour
    {
        private List<LevelConfig> _levelConfigs;
        private MainConfig _mainConfig;
        private SettingsPanel _settingsPanel;
        private GameUIController _gameUIController;
        private ShootPresenter _shootPresenter;
        private int _currentLevelIndex;
        private WeaponConfig _weaponConfig;
        private bool _isCheckComplete;
        private SignalBus _signalBus;

        private IDisposable _timerObservable;

        private const float TargetYPosition = 10f;
        private const float TimeToMoveToNextLevel = 1.5f;

        [Inject]
        private void Constructor(
            SignalBus signalBus,
            MainConfig mainConfig,
            SettingsPanel settingsPanel,
            GameUIController gameUIController,
            ShootPresenter shootPresenter)
        {
            _signalBus = signalBus;
            _mainConfig = mainConfig;
            _settingsPanel = settingsPanel;
            _gameUIController = gameUIController;
            _shootPresenter = shootPresenter;
        }

        private void Awake()
        {
            _settingsPanel
                .StartButton
                .onClick
                .AddListener(OnClickStartButton);
            
            _levelConfigs = _mainConfig.LevelConfigs;
        }

        private void OnDestroy()
        {
            _timerObservable?.Dispose();
            
            if (_settingsPanel != null)
            {
                _settingsPanel
                    .StartButton
                    .onClick
                    .RemoveListener(OnClickStartButton);
            }
        }

        private void OnClickStartButton()
        {
            _weaponConfig = _settingsPanel.GetCurrentWeaponConfig();
            _gameUIController.SetBulletAmount(_weaponConfig.BulletAmount);
            var levelInfo = _levelConfigs.FirstOrDefault(i => i.LevelIndex == _currentLevelIndex);

            if (levelInfo != null)
            {
                _gameUIController.SetLevelIndex = levelInfo.LevelIndex;
            }
            
            _shootPresenter.Prepare(_weaponConfig);
            _shootPresenter.UnlockPlayerControl();
            
            _settingsPanel.IsVisible = false;
        }

        /*private void OnHitTarget(ShotSignals.HitTarget signal)
        {
            if (_isCheckComplete) return;
            _isCheckComplete = true;

            signal.Block.Hide();
            var value = signal.Block.Points * _weaponConfig.ScoringRatio;
            _gameUIController.UpdateScore(value);
            
            CheckLevelComplete();
        }*/

        private void CheckLevelComplete()
        {
            var levelInfo = _levelConfigs.FirstOrDefault(i => i.LevelIndex == _currentLevelIndex);
            if (levelInfo && levelInfo.PointsToComplete <= _gameUIController.CurrentScore)
            {
                _timerObservable?.Dispose();
                _shootPresenter.BlockPlayerControl();
                
                if (++_currentLevelIndex < _levelConfigs.Count)
                {
                    _timerObservable = Observable
                        .Timer(TimeSpan.FromSeconds(TimeToMoveToNextLevel))
                        .Subscribe(_ => GoToNextLevel());
                }
                else
                {
                    _gameUIController.SetLevelText = "Game completed!";
                }
            }
            else
            {
                _isCheckComplete = false;
            }
        }

        private void GoToNextLevel()
        {
            _gameUIController.SetLevelIndex= _currentLevelIndex;
            _gameUIController.ShowAllBullets();
            _gameUIController.ResetScore();
            
            var levelInfo = _levelConfigs.FirstOrDefault(i => i.LevelIndex == _currentLevelIndex);
            if (levelInfo == null) return;
            
            _shootPresenter.ResetParams();
            _shootPresenter.UnlockPlayerControl();

            _isCheckComplete = false;
        }
    }
}