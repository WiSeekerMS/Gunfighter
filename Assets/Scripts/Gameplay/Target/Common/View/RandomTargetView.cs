using System.Collections.Generic;
using System.Linq;
using Gameplay.Target.Configs;
using UnityEngine;

namespace Gameplay.Target.Common.View
{
    public class RandomTargetView : MonoBehaviour
    {
        [SerializeField] private BaseTargetConfig _targetConfig;
        private List<ShardView> _shardViews;
        private List<Collider> _colliders;

        private void Awake()
        {
            Destroy(transform
                .GetChild(0)
                .gameObject);

            var prefabIndex = Random.Range(0, _targetConfig.TargetPrefabs.Count);
            var prefab = _targetConfig.TargetPrefabs[prefabIndex];
            var target = Instantiate(prefab, transform);
            target.transform.localPosition = Vector3.zero;
        }

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