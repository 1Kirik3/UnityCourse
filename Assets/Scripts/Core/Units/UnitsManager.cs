using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Units
{
    public class UnitsManager : MonoBehaviour
    {
        [SerializeField] private List<Unit> _units = new List<Unit>();
        [SerializeField] private Unit _unitPrefab;
        [SerializeField] private Transform _spawnPoint;

        public event Action UnitBecameFree;
        public event Action<Unit, Vector3> UnitReadyToBuildBase;

        public int UnitsCount => _units.Count;

        private void OnEnable()
        {
            foreach (var unit in _units)
            {
                SubscribeToUnit(unit);
            }
        }

        private void OnDisable()
        {
            foreach (var unit in _units)
            {
                UnsubscribeFromUnit(unit);
            }
        }

        public void ClearAllUnits()
        {
            foreach (var unit in _units)
            {
                UnsubscribeFromUnit(unit);
            }

            _units.Clear();
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

        public void SpawnNewUnit()
        {
            Unit newUnit = Instantiate(_unitPrefab, _spawnPoint.position, Quaternion.identity);
            AddUnit(newUnit);
        }

        public void AddUnit(Unit unit)
        {
            if (_units.Contains(unit))
            {
                return;
            }

            _units.Add(unit);
            SubscribeToUnit(unit);
            UnitBecameFree?.Invoke();
        }

        public void RemoveUnit(Unit unit)
        {
            if (_units.Remove(unit))
            {
                UnsubscribeFromUnit(unit);
            }
        }

        private void SubscribeToUnit(Unit unit)
        {
            unit.BaseBuildReached += HandleBaseBuildReached;
        }

        private void UnsubscribeFromUnit(Unit unit)
        {
            unit.BaseBuildReached -= HandleBaseBuildReached;
        }

        private void HandleBaseBuildReached(Unit builderUnit, Vector3 buildPosition)
        {
            UnitReadyToBuildBase?.Invoke(builderUnit, buildPosition);
        }
    }
}
