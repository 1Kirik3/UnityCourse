using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Spawners
{
    public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected T Prefab;
        [SerializeField] protected List<Transform> SpawnPoints;

        protected virtual void Start()
        {
            SpawnAll();
        }

        public virtual void SpawnAll()
        {
            if (Prefab == null || SpawnPoints == null || SpawnPoints.Count == 0)
                return;

            foreach (Transform point in SpawnPoints)
            {
                if (point != null)
                    Spawn(point);
            }
        }

        protected virtual void Spawn(Transform point)
        {
            Instantiate(Prefab, point.position, Quaternion.identity, transform);
        }
    }
}

