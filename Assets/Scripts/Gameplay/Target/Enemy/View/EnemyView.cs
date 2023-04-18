using Common;
using Gameplay.Target.Configs;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay.Target.Enemy.View
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private int _test;
        [Inject] private EnemyConfig _enemyConfig;
        private float _enemyHP;
        private bool _isBlockDamage;
        private Vector3 _destination;
        private NavMeshAgent _agent;
        
        private static readonly int IsKilled = Animator.StringToHash("IsKilled");
        private static readonly int KilledAnimationIndex = Animator.StringToHash("Killed_Index");
        private static readonly int IsMirror = Animator.StringToHash("IsMirror");

        private void Start()
        {
            _enemyHP = _enemyConfig.HP;
            _destination = Vector3.zero;
            
            _agent = GetComponent<NavMeshAgent>();
            _agent.destination = _destination;
            _agent.speed = _enemyConfig.MoveSpeed;
            
            _animator.SetInteger("TestInt", _test);
        }

        public void SetAnimationState(EnemyAnimationState state)
        {
            var index = Random.Range(0, 3);
            var isMirror = Random.value > 0.5f;

            _animator.SetInteger(KilledAnimationIndex, index);
            _animator.SetBool(IsMirror, isMirror);
            _animator.SetTrigger(IsKilled);
        }

        public void SetDamage(float damage)
        {
            _enemyHP -= damage;
            if (_enemyHP > 0f || _isBlockDamage)
                return;

            _isBlockDamage = true;
            OnKilled();
        }

        private void Update()
        {
            var distance = Vector3.Distance(transform.position, _destination);
            if (distance <= _agent.stoppingDistance)
            {
            }
        }

        private void OnKilled()
        {
            _agent.isStopped = true;
            SetAnimationState(EnemyAnimationState.Dying);
        }
    }
}