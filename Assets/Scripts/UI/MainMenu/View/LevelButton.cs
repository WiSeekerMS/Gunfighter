using System;
using Common;
using Common.Interfaces;
using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.View
{
    [RequireComponent(typeof(Button))]
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private ButtonAccessLevel _accessLevel;
        [SerializeField] private Button _button;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _textMesh;
        [SerializeField, HideInInspector] private ButtonAccessLevel _lastAccessLevel;
        [SerializeField, HideInInspector] private bool _blockOnRun;
        [SerializeField, HideInInspector] private Sprite _spriteOnRun;
        [SerializeField, HideInInspector] private int _levelIndexOnRun;

        public event Action<ISceneInfo> ClickOnLevelButton;

        private void Awake()
        {
            _button.onClick.AddListener(OnClickButton);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void Start()
        {
            if (_blockOnRun)
            {
                _button.interactable = false;
                _icon.sprite = _spriteOnRun;
                _textMesh.text = string.Empty;
            }
            else
            {
                _textMesh.text = (transform.GetSiblingIndex() + 1).ToString();
            }
        }
        
        private void OnClickButton()
        {
            ClickOnLevelButton?.Invoke(_levelConfig);
        }

        #region In Editor Mode
        public void UpdateSiblingPosition(int index)
        {
            _levelIndexOnRun = index + 1; 
            gameObject.name = $"LevelButton_{_levelIndexOnRun}";
            _textMesh.text = _accessLevel == ButtonAccessLevel.Available
                ? _levelIndexOnRun.ToString()
                : string.Empty;
        }

        private void UnlockButton()
        {
            _textMesh.text = _levelIndexOnRun.ToString();
            _icon.enabled = false;
            _button.interactable = true;
            _blockOnRun = false;
            _spriteOnRun = null;
        }

        private void BlockButton(string iconPath)
        {
            _textMesh.text = string.Empty;
            _button.interactable = false;
            _blockOnRun = true;
                
            var sprite = Utils.GetSpriteFromPath(iconPath);
            if (!sprite) return;
            _spriteOnRun = sprite;
            _icon.sprite = sprite;
            _icon.enabled = true;
        }

        public void OnGUIChanged(bool isForce = false)
        {
            if (Application.isPlaying)
            {
                return;
            }

            if (_lastAccessLevel == _accessLevel
                && !isForce)
            {
                return;
            }
            
            _lastAccessLevel = _accessLevel;
            switch (_accessLevel)
            {
                case ButtonAccessLevel.Blocked:
                    BlockButton(Constants.BlockedIconPath);
                    break;
                case ButtonAccessLevel.InDeveloping:
                    BlockButton(Constants.ComingSoonIconPath);
                    break;
                default:
                    UnlockButton();
                    break;
            }
        }
        #endregion
    }
}