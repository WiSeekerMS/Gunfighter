using UI.MainMenu.View;
using UnityEditor;
using UnityEngine;

namespace UI.MainMenu.Editor
{
    [CustomEditor(typeof(LevelButton))]
    public class LevelButtonEditor : UnityEditor.Editor
    {
        private LevelButton _levelButton;

        private void Awake()
        {
            _levelButton = target as LevelButton;
            if (_levelButton && !Application.isPlaying)
            {
                _levelButton.OnGUIChanged(true);
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (!GUI.changed) return;
            _levelButton.OnGUIChanged();
        }
    }
}