using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyRotator : MonoBehaviour
    {
        [Header("Rotation Settings")]
        [SerializeField] private float _rotationSpeed = 10.0f;

        [SerializeField] private Rigidbody _rigidbody;

        public void RotateTowardsDirection(Vector3 direction)
        {
            if (direction == Vector3.zero) 
                return;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion smoothedRotation = Quaternion.Slerp(_rigidbody.rotation, targetRotation, Time.fixedDeltaTime * _rotationSpeed);

            _rigidbody.MoveRotation(smoothedRotation);
        }
    }
}
