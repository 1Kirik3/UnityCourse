using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Core
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Resource : MonoBehaviour, IResource
    {
        private Rigidbody _rb;
        private Collider _col;
        private Action<Resource> _returnToPoolAction;

        public Vector3 Position => transform.position;
        public bool IsTargeted { get; private set; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _col = GetComponent<Collider>();
        }
        public void Initialize(Action<Resource> onRelease)
        {
            _returnToPoolAction = onRelease;
            IsTargeted = false;

            _rb.isKinematic = false;
            _col.enabled = true;
        }

        public void SetTargeted(bool state)
        {
            IsTargeted = state;
        }

        public void PickUp(Transform carryPoint)
        {
            _rb.isKinematic = true;
            _col.enabled = false;

            transform.SetParent(carryPoint);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }

        public void Collect()
        {
            transform.SetParent(null);
            _returnToPoolAction?.Invoke(this);
        }
    }
}
