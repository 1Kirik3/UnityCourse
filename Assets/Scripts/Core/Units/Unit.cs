using Assets.Scripts.Core.Base;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core.Units
{
    [RequireComponent(typeof(UnitMover))]
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Transform _carryPoint;

        public event Action<Unit, Vector3> BaseBuildReached;

        private UnitMover _mover;
        private Coroutine _currentTaskRoutine;
        private bool _isBusy;

        public bool IsFree => !_isBusy;

        private void Awake()
        {
            _mover = GetComponent<UnitMover>();
        }

        public void AssignCollectTask(IResource resource, CollectionPoint dropOffPoint)
        {
            StartNewTask(CollectRoutine(resource, dropOffPoint));
        }

        public void AssignBuildTask(Vector3 targetPosition)
        {
            StartNewTask(BuildRoutine(targetPosition));
        }

        public void CancelCurrentTask()
        {
            if (_currentTaskRoutine != null)
            {
                StopCoroutine(_currentTaskRoutine);
                _currentTaskRoutine = null;
            }

            _mover.Stop();
            _isBusy = false;
        }

        private void StartNewTask(IEnumerator taskRoutine)
        {
            CancelCurrentTask();
            _isBusy = true;
            _currentTaskRoutine = StartCoroutine(taskRoutine);
        }

        private IEnumerator CollectRoutine(IResource resource, CollectionPoint dropOffPoint)
        {
            yield return _mover.MoveToPositionRoutine(resource.Position);

            resource.PickUp(_carryPoint);

            Vector3 targetDropOffPosition = dropOffPoint.GetDropOffPosition();
            yield return _mover.MoveToPositionRoutine(targetDropOffPosition);

            resource.Collect();
            _isBusy = false;

            dropOffPoint.FinishTask(this);
        }

        private IEnumerator BuildRoutine(Vector3 targetPosition)
        {
            yield return _mover.MoveToPositionRoutine(targetPosition);

            _isBusy = false;
            BaseBuildReached?.Invoke(this, targetPosition);
        }
    }
}
