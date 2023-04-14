using System.Collections.Generic;
using System.Linq;
using Configs;
using Gameplay.ShotSystem.Configs;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class SettingsPanel : PanelController
    {
        [SerializeField] private ScrollRect _weaponsSR;
        [SerializeField] private Button _startButton;
        private RectTransform _weaponsContainer;
        private HorizontalLayoutGroup _weaponsLayoutGroup;
        private MainConfig _mainConfig;
        private List<WeaponInfo> _weaponInfos;

        public Button StartButton => _startButton;

        [Inject]
        private void Constructor(MainConfig mainConfig)
        {
            _mainConfig = mainConfig;
        }

        private void Start()
        {
            _weaponsContainer = _weaponsSR.content;
            _weaponsLayoutGroup = _weaponsContainer.GetComponent<HorizontalLayoutGroup>();
            FillWeaponsList();
        }

        private void FillWeaponsList()
        {
            _weaponInfos = new List<WeaponInfo>();
            var configs = _mainConfig.WeaponConfigs;
            var infoPrefab = _mainConfig.WeaponInfoPrefab;
            
            foreach (var config in configs)
            {
                var info = Instantiate(infoPrefab, _weaponsContainer);
                _weaponInfos.Add(info);
                info.Init(config);
            }
            
            var spacing = _weaponsLayoutGroup != null 
                ? _weaponsLayoutGroup.spacing 
                : 0f;

            var offsetMax = _weaponsContainer.offsetMax;
            var prefabTransform = infoPrefab.transform as RectTransform;
            var rightShift = prefabTransform.sizeDelta.x * configs.Count + (configs.Count * spacing);

            _weaponsContainer.offsetMax = new Vector2
            {
                x = offsetMax.x + rightShift, 
                y = offsetMax.y
            };

            var firstInfo = _weaponInfos.First();
            if (firstInfo) firstInfo.IsOn = true;
            
            _weaponInfos
                .ForEach(i => i.Toggle.onValueChanged.AddListener(_ => OnChangeToggleValue(i)));
        }

        private void OnChangeToggleValue(WeaponInfo info)
        {
            _weaponInfos
                .ForEach(i => i.Toggle.onValueChanged.RemoveAllListeners());

            _weaponInfos.FindAll(i => i != info)
                .ForEach(i =>
                {
                    i.IsOn = false;
                    i.Toggle.onValueChanged.AddListener(_ => OnChangeToggleValue(i));
                });
        }

        public WeaponConfig GetCurrentWeaponConfig()
        {
            return _weaponsContainer
                .GetComponentsInChildren<WeaponInfo>()
                .ToList()
                .FirstOrDefault(i => i.IsOn)
                ?.Config;
        }
    }
}