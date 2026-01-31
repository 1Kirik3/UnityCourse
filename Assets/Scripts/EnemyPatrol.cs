using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _arrivalDistance = 0.2f;

    [SerializeField] private List<Transform> _waypoints = new List<Transform>();
   
    private int _currentWaypointIndex = 0;

    private void Update()
    {
        PatrolWaypoints();
    }

    private void PatrolWaypoints()
    {
        if (_waypoints == null || _waypoints.Count == 0) return;

        Transform target = _waypoints[_currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        float directionX = target.position.x - transform.position.x;

        if (Vector2.Distance(transform.position, target.position) < _arrivalDistance)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Count;
        }

        return;
    }
}