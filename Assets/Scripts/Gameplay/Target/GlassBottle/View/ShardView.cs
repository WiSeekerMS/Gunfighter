using System;
using UnityEngine;

namespace Gameplay.Target.GlassBottle.View
{
    public class ShardView : MonoBehaviour
    {
        public Rigidbody Rb;
        public Collider ShardCollider;
        public MeshFilter Filter;

        private void Awake()
        {
            Rb = GetComponent<Rigidbody>();
            ShardCollider = GetComponent<Collider>();
            Filter = GetComponent<MeshFilter>();
        }

        private void Start()
        {
            ShardCollider.enabled = false;
        }

        public void AddForce(Vector3 vector)
        {
            ShardCollider.enabled = true;
            Rb.useGravity = true;
            var direction = (transform.position - vector).normalized; 
            Rb.AddForce(direction * 30f, ForceMode.Impulse);
        }
    }
}