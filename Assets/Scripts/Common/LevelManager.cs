using System;
using System.Collections.Generic;
using System.Linq;
using Configs;
using Gameplay.ShootSystem.Presenters;
using Gameplay.ShotSystem.Configs;
using Gameplay.ShotSystem.Signals;
using UI;
using UniRx;
using UnityEngine;
using Zenject;

namespace Common
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private WeaponConfig _weaponConfig;
        private List<LevelConfig> _levelConfigs;
        private MainConfig _mainConfig;
        private SignalBus _signalBus;
        private SettingsPanel _settingsPanel;
        private GameUIController _gameUIController;
        private ShotPresenter _shotPresenter;
        private int _currentLevelIndex;
        private bool _isCheckComplete;

        private IDisposable _timerObservable;
        private const float TimeToMoveToNextLevel = 1.5f;

        [Inject]
        private void Constructor(
            MainConfig mainConfig,
            SignalBus signalBus,
            SettingsPanel settingsPanel,
            GameUIController gameUIController,
            ShotPresenter shotPresenter)
        {
            _mainConfig = mainConfig;
            _signalBus = signalBus;
            _settingsPanel = settingsPanel;
            _gameUIController = gameUIController;
            _shotPresenter = shotPresenter;
        }

        private void Awake()
        {
            _settingsPanel
                .StartButton
                .onClick
                .AddListener(OnClickStartButton);
            
            _levelConfigs = _mainConfig.LevelConfigs;
            
            _signalBus.Subscribe<ShotSignals.Hit>(OnHit);
        }

        private void Start()
        {
            OnClickStartButton();
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
            
            _signalBus.Unsubscribe<ShotSignals.Hit>(OnHit);
        }

        private void OnHit(ShotSignals.Hit signal)
        {
            _gameUIController.AddDamagePoint(signal.HitInfo.point);
        }

        private void OnClickStartButton()
        {
            //_weaponConfig = _settingsPanel.GetCurrentWeaponConfig();
            _gameUIController.SetBulletAmount(_weaponConfig.BulletAmount);
            var levelInfo = _levelConfigs.FirstOrDefault(i => i.LevelIndex == _currentLevelIndex);

            if (levelInfo != null)
            {
                _gameUIController.SetLevelIndex = levelInfo.LevelIndex;
            }
            
            _shotPresenter.Prepare(_weaponConfig);
            _shotPresenter.UnlockPlayerControl();
            
            _settingsPanel.IsVisible = false;
        }

        private void CheckLevelComplete()
        {
            var levelInfo = _levelConfigs.FirstOrDefault(i => i.LevelIndex == _currentLevelIndex);
            if (levelInfo && levelInfo.PointsToComplete <= _gameUIController.CurrentScore)
            {
                _timerObservable?.Dispose();
                _shotPresenter.BlockPlayerControl();
                
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
            
            _shotPresenter.ResetParams();
            _shotPresenter.UnlockPlayerControl();

            _isCheckComplete = false;
        }
    }
}