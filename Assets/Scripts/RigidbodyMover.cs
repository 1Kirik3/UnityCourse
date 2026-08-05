using System;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyMover : MonoBehaviour
    {
        [Header("Speed Settings")]
        [SerializeField] private float _moveSpeed = 4.5f;

        [SerializeField] private Rigidbody _rigidbody;

        public float MoveSpeed => _moveSpeed;

        public void MoveInDirection(Vector3 direction)
        {
            if (direction == Vector3.zero) 
                return;

            Vector3 nextPosition = _rigidbody.position + direction * _moveSpeed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(nextPosition);
        }
    }
}
