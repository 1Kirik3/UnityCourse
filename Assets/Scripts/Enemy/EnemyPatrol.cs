using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _arrivalDistance = 0.2f;

        [SerializeField] private List<Transform> _waypoints = new List<Transform>();

        private float _sqrArrivalDistance = 0;
        private int _currentWaypointIndex = 0;

        private void Start()
        {
            _sqrArrivalDistance = _arrivalDistance * _arrivalDistance;
        }

        public void PatrolWaypoints()
        {
            if (_waypoints == null || _waypoints.Count == 0) 
                return;

            Transform target = _waypoints[_currentWaypointIndex];
            transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
            float directionX = target.position.x - transform.position.x;

            Vector2 diff = (Vector2)target.position - (Vector2)transform.position;

            if (diff.sqrMagnitude < _sqrArrivalDistance)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Count;
            }

            return;
        }
    }
}
