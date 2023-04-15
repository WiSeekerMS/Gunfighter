using Gameplay.Target.Enums;
using UnityEngine;

namespace Gameplay.Target.Enemy.View
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private static readonly int IsKilled = Animator.StringToHash("IsKilled");

        public void SetAnimationState(EnemyAnimationState state)
        {
            _animator.SetTrigger(IsKilled);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Q))
                SetAnimationState(EnemyAnimationState.Dying);
        }
    }
}