using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class Base : MonoBehaviour, IBase
    {
        private const int InitialResourceCount = 0;

        [Header("Base Settings")]
        [SerializeField] private float _scanRadius = 50f;
        [SerializeField] private LayerMask _resourceLayer;
        [SerializeField] private float _scanInterval = 1f;

        [Header("Units")]
        [SerializeField] private List<Unit> _units;

        public event Action<int> OnResourcesChanged;

        private int _collectedResourcesAmount = InitialResourceCount;
        private float _scanTimer;

        public Vector3 Position => transform.position;

        private void Start()
        {
            OnResourcesChanged?.Invoke(_collectedResourcesAmount);
        }

        private void Update()
        {
            _scanTimer += Time.deltaTime;

            if (_scanTimer >= _scanInterval)
            {
                _scanTimer = 0f;
                ScanAndDispatch();
            }
        }

        private void ScanAndDispatch()
        {
            Unit freeUnit = GetFreeUnit();

            if (freeUnit == null) 
                return;

            Collider[] colliders = Physics.OverlapSphere(transform.position, _scanRadius, _resourceLayer);

            foreach (var col in colliders)
            {
                if (col.TryGetComponent(out IResource resource))
                {
                    if (!resource.IsTargeted)
                    {
                        freeUnit.AssignTask(resource, this);
                        break;
                    }
                }
            }
        }

        private Unit GetFreeUnit()
        {
            foreach (var unit in _units)
            {
                if (unit.IsFree) return unit;
            }

            return null;
        }

        public void ReceiveResource()
        {
            _collectedResourcesAmount++;
            OnResourcesChanged?.Invoke(_collectedResourcesAmount);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _scanRadius);
        }
    }
}
