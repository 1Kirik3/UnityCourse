using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyAI _enemyAI;

        private void Update()
        {
            _enemyAI.SimulateBehavior();
        }

    }
}
