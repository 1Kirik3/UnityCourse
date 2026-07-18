using Assets.Scripts.Core.Units;
using System;
using UnityEngine;

namespace Assets.Scripts.Core.Base
{
    public class CollectionPoint : MonoBehaviour
    {
        [SerializeField] private float _dropOffRadius = 2.0f;

        public event Action<Unit> UnitTaskFinished;

        public Vector3 GetDropOffPosition()
        {
            Vector2 randomCircle = UnityEngine.Random.insideUnitCircle * _dropOffRadius;
            return new Vector3(
                transform.position.x + randomCircle.x,
                transform.position.y,
                transform.position.z + randomCircle.y
            );
        }

        public void FinishTask(Unit unit)
        {
            UnitTaskFinished?.Invoke(unit);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _dropOffRadius);
        }
    }
}
