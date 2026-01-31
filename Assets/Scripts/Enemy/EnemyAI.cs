using Assets.Scripts.Enemy;

using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _viewRange = 3f;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private EnemyPatrol _patrol;

    private Transform _target;

    public void SimulateBehavior()
    {
        _target = FindTarget();

        if (_target != null)
        {
            ChaseTarget();
        }
        else
        {
            _patrol.PatrolWaypoints();
        }
    }

    private Transform FindTarget()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _viewRange, _playerLayer);
        return hit != null ? hit.transform : null;
    }

    private void ChaseTarget()
    {
        Vector2 direction = (_target.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, _target.position, Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _viewRange);
    }
}
