using UnityEngine;

namespace Gameplay.Target.GlassBottle.View
{
    public class ShardView : MonoBehaviour
    {
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
            _rb.AddForce(direction * 30f, ForceMode.Impulse);
        }
    }
}