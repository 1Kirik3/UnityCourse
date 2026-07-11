using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Core.ResourcesLogic
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Resource : MonoBehaviour, IResource
    {
        private Rigidbody _rigidbody;
        private Collider _collider;

        public event Action<IResource> Collected;

        public Vector3 Position => transform.position;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        public void PickUp(Transform carryPoint)
        {
            _rigidbody.isKinematic = true;
            _collider.enabled = false;

            transform.SetParent(carryPoint);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }

        public void Collect()
        {
            transform.SetParent(null);
            Collected?.Invoke(this);
        }

        public void ResetState()
        {
            _rigidbody.isKinematic = false;
            _collider.enabled = true;
        }
    }
}
