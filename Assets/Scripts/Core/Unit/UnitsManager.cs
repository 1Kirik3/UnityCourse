using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Unit
{
    public class UnitManager : MonoBehaviour
    {
        [SerializeField] private List<Unit> _units;

        public event Action UnitBecameFree;

        private void OnEnable()
        {
            foreach (var unit in _units)
            {
                unit.ResourceDelivered += HandleResourceDelivered;
            }
        }

        private void OnDisable()
        {
            foreach (var unit in _units)
            {
                unit.ResourceDelivered -= HandleResourceDelivered;
            }
        }

        public Unit GetFreeUnit()
        {
            foreach (var unit in _units)
            {
                if (unit.IsFree)
                {
                    return unit;
                }
            }

            return null;
        }

        private void HandleResourceDelivered(Unit unit)
        {
            UnitBecameFree?.Invoke();
        }
    }
}
