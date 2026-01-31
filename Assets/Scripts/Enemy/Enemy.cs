using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyPatrol _enemyPatrol;

        private void Update()
        {
            _enemyPatrol.PatrolWaypoints();
        }

    }
}
