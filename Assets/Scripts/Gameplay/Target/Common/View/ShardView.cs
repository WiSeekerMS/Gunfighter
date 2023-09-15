using UnityEngine;

namespace Gameplay.Target.Common.View
{
    public class ShardView : MonoBehaviour
    {
        [SerializeField] private float _force = 30f;
        private Rigidbody _rb;
        private Collider _shardCollider;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _shardCollider = GetComponent<Collider>();
        }

        private void Start()
        {
            _shardCollider.enabled = false;
        }

        public void AddForce(Vector3 vector)
        {
            _shardCollider.enabled = true;
            _rb.useGravity = true;
            var direction = (transform.position - vector).normalized; 
            _rb.AddForce(direction * _force, ForceMode.Impulse);
        }
    }
}