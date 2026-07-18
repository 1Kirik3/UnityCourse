using Assets.Scripts.Core.ResourcesLogic;
using Assets.Scripts.Core.Units;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Core.Base
{
    public class BaseController : MonoBehaviour
    {
        [SerializeField] private BaseStorage _storage;
        [SerializeField] private UnitsManager _unitManager;
        [SerializeField] private CollectionPoint _collectionPoint;
        [SerializeField] private BaseFlag _flag;
        [SerializeField] private BaseController _basePrefab;
        [SerializeField] private ResourceDatabase _resourceDatabase;
        [SerializeField] private float _spawnHeightOffset = 0.1f;
        [SerializeField] private LayerMask _groundLayer;

        private const int UnitCost = 3;
        private const int BaseCost = 5;

        private bool _isBuildingBaseInProgress;
        private bool _isEvaluating;

        private void Start()
        {
            if (_resourceDatabase != null)
            {
                _resourceDatabase.ResourceAdded += EvaluateStateAndDispatch;
            }

            EvaluateStateAndDispatch();
        }

        private void OnEnable()
        {
            _unitManager.UnitBecameFree += EvaluateStateAndDispatch;
            _unitManager.UnitReadyToBuildBase += HandleUnitReadyToBuildBase;
            _storage.ResourcesChanged += HandleResourcesChanged;
            _collectionPoint.UnitTaskFinished += HandleUnitReturned;
        }

        private void OnDisable()
        {
            _unitManager.UnitBecameFree -= EvaluateStateAndDispatch;
            _unitManager.UnitReadyToBuildBase -= HandleUnitReadyToBuildBase;
            _storage.ResourcesChanged -= HandleResourcesChanged;
            _collectionPoint.UnitTaskFinished -= HandleUnitReturned;

            if (_resourceDatabase != null)
            {
                _resourceDatabase.ResourceAdded -= EvaluateStateAndDispatch;
            }
        }

        public void SetupNewBase(ResourceDatabase database, Unit firstUnit)
        {
            _unitManager.ClearAllUnits();

            if (_resourceDatabase != null)
            {
                _resourceDatabase.ResourceAdded -= EvaluateStateAndDispatch;
            }

            _resourceDatabase = database;
            _resourceDatabase.ResourceAdded += EvaluateStateAndDispatch;

            _unitManager.AddUnit(firstUnit);

            EvaluateStateAndDispatch();
        }

        public void SetFlagPosition(Vector3 position)
        {
            _flag.PlaceAt(position);
            EvaluateStateAndDispatch();
        }

        private void HandleResourcesChanged(int currentAmount)
        {
            EvaluateStateAndDispatch();
        }

        private void HandleUnitReturned(Unit unit)
        {
            _storage.AddResource();
            EvaluateStateAndDispatch();
        }

        private void EvaluateStateAndDispatch()
        {
            if (_isEvaluating || _isBuildingBaseInProgress)
            {
                return;
            }

            _isEvaluating = true;

            try
            {
                if (_flag.IsPlaced && _unitManager.UnitsCount > 1)
                {
                    if (_storage.CurrentAmount >= BaseCost)
                    {
                        TrySendUnitToBuildBase();
                        return;
                    }
                }
                else if (_storage.CurrentAmount >= UnitCost)
                {
                    if (_storage.TrySpend(UnitCost))
                    {
                        _unitManager.SpawnNewUnit();
                        return;
                    }
                }

                DispatchFreeUnitsToCollect();
            }
            finally
            {
                _isEvaluating = false;
            }
        }

        private void TrySendUnitToBuildBase()
        {
            Unit freeUnit = _unitManager.GetFreeUnit();

            if (freeUnit == null)
            {
                return;
            }

            if (_storage.TrySpend(BaseCost))
            {
                _isBuildingBaseInProgress = true;
                freeUnit.AssignBuildTask(_flag.Position);
            }
        }

        private void HandleUnitReadyToBuildBase(Unit builderUnit, Vector3 buildPosition)
        {
            _isBuildingBaseInProgress = false;

            Vector3 correctedPosition = buildPosition;

            Ray ray = new Ray(buildPosition + Vector3.up * 10f, Vector3.down);

            if (Physics.Raycast(ray, out RaycastHit hit, 20f, _groundLayer))
            {
                correctedPosition = hit.point + Vector3.up * _spawnHeightOffset;
            }
            else
            {
                correctedPosition = buildPosition + Vector3.up * _spawnHeightOffset;
            }

            BaseController newBase = Instantiate(_basePrefab, correctedPosition, Quaternion.identity);

            newBase.SetupNewBase(_resourceDatabase, builderUnit);
            _unitManager.RemoveUnit(builderUnit);

            _flag.Hide();
            EvaluateStateAndDispatch();
        }

        private void DispatchFreeUnitsToCollect()
        {
            if (_resourceDatabase == null) return;

            while (true)
            {
                Unit freeUnit = _unitManager.GetFreeUnit();

                if (freeUnit == null)
                {
                    break;
                }

                if (_resourceDatabase.TryGetUnreservedResource(out IResource resource))
                {
                    freeUnit.AssignCollectTask(resource, _collectionPoint);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
