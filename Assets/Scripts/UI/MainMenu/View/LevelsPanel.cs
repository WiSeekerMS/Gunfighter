using System.Collections.Generic;
using Common.Interfaces;
using UI.MainMenu.Controllers;
using UnityEngine;
using Zenject;

namespace UI.MainMenu.View
{
    public class LevelsPanel : MonoBehaviour
    {
        [SerializeField] private List<LevelButton> _levelButtons;
        [Inject] private MainMenuController _mainMenuController;

        private void Awake()
        {
            foreach (var button in _levelButtons)
            {
                button.ClickOnLevelButton += OnClickLevelButton;
            }
        }

        private void OnDestroy()
        {
            foreach (var button in _levelButtons)
            {
                button.ClickOnLevelButton -= OnClickLevelButton;
            }
        }

        private void OnClickLevelButton(ISceneInfo info)
        {
            _mainMenuController.LoadScene(info);
        }
    }
}