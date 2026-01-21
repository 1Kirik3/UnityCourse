using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private float _speed = 3f;

    private int _currentWaypointIndex = 0;

    private void Start()
    {
        _renderer.material.color = Random.ColorHSV();
    }

    private void Update()
    {
        if (_waypoints.Count == 0) return;

        Transform targetWaypoint = _waypoints[_currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Count;
        }
    }
}
