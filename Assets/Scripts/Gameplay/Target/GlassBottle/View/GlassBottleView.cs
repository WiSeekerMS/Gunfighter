using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Target.GlassBottle.View
{
    public class GlassBottleView : MonoBehaviour
    {
        private List<ShardView> _shardViews;
        private List<Collider> _colliders;

        private void Start()
        {
            _colliders = transform.GetComponents<Collider>().ToList();
            _shardViews = transform.GetComponentsInChildren<ShardView>().ToList();
            Physics.IgnoreLayerCollision(19, 19);
        }

        public void OnHit(Vector3 point)
        {
            _colliders.ForEach(c => c.enabled = false);
            _shardViews.ForEach(s => s.AddForce(point));
        }
    }
}