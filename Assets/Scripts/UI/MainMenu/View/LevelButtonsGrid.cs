using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.View
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(GridLayoutGroup))]
    public class LevelButtonsGrid : MonoBehaviour
    {
        private void OnTransformChildrenChanged()
        {
            if (Application.isPlaying) 
                return;
            
            for (int i = 0; i < transform.childCount; i++)
            {
                var button = transform.GetChild(i).GetComponent<LevelButton>();
                if (!button) continue;
                
                button.UpdateSiblingPosition(i);
            }
        }
    }
}