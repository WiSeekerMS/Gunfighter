using System;
using System.Collections.Generic;
using System.Linq;
using Configs;
using Gameplay.ShotSystem.Configs;
using Gameplay.ShotSystem.Presenters;
using Gameplay.ShotSystem.Signals;
using UI;
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
        private GameUIController _gameUIController;
        private ShotPresenter _shotPresenter;
        private int _currentLevelIndex;
        private bool _isCheckComplete;
        private IDisposable _timerObservable;

        [Inject]
        private void Constructor(
            MainConfig mainConfig,
            SignalBus signalBus,
            GameUIController gameUIController,
            ShotPresenter shotPresenter)
        {
            _mainConfig = mainConfig;
            _signalBus = signalBus;
            _gameUIController = gameUIController;
            _shotPresenter = shotPresenter;
        }

        private void Awake()
        {
            _levelConfigs = _mainConfig.LevelConfigs;
            _signalBus.Subscribe<ShotSignals.Hit>(OnHit);
        }

        private void Start()
        {
            _gameUIController.SetBulletAmount(_weaponConfig.BulletAmount);
            var levelInfo = _levelConfigs.FirstOrDefault(i => i.LevelIndex == _currentLevelIndex);

            _shotPresenter.Prepare(_weaponConfig);
            _shotPresenter.UnlockPlayerControl();
        }

        private void OnDestroy()
        {
            _timerObservable?.Dispose();
            _signalBus.Unsubscribe<ShotSignals.Hit>(OnHit);
        }

        private void OnHit(ShotSignals.Hit signal)
        {
            _gameUIController.AddDamagePoint(signal.HitInfo.point);
            _gameUIController.UpdateScore(5f);
        }
    }
}