using Assets.Scripts.Core.ResourcesLogic;
using Assets.Scripts.Core.Unit;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Core.Base
{
    public class BaseController : MonoBehaviour
    {
        [SerializeField] private BaseStorage _storage;
        [SerializeField] private UnitManager _unitManager;
        [SerializeField] private ResourceDatabase _resourceDatabase;
        [SerializeField] private Transform _dropOffPoint;

        private void OnEnable()
        {
            _unitManager.UnitBecameFree += TryDispatchNextTask;
        }

        private void OnDisable()
        {
            _unitManager.UnitBecameFree -= TryDispatchNextTask;
        }

        private void Update()
        {
            TryDispatchNextTask();
        }

        private void TryDispatchNextTask()
        {
            Unit.Unit freeUnit = _unitManager.GetFreeUnit();
            if (freeUnit == null)
            {
                return;
            }

            if (_resourceDatabase.TryGetUnreservedResource(out IResource resource))
            {
                freeUnit.ResourceDelivered += HandleTaskCompleted;
                freeUnit.AssignTask(resource, _dropOffPoint);
            }
        }

        private void HandleTaskCompleted(Unit.Unit unit)
        {
            unit.ResourceDelivered -= HandleTaskCompleted;
            _storage.AddResource();
        }
    }
}
