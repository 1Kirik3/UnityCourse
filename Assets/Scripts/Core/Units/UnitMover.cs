using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Core.Units
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class UnitMover : MonoBehaviour
    {
        private NavMeshAgent _navigationAgent;

        private void Awake()
        {
            _navigationAgent = GetComponent<NavMeshAgent>();
        }

        public IEnumerator MoveToPositionRoutine(Vector3 destination)
        {
            _navigationAgent.SetDestination(destination);

            yield return null;

            while (_navigationAgent.pathPending)
            {
                yield return null;
            }

            float arrivalThreshold = _navigationAgent.stoppingDistance + 0.1f;

            while (_navigationAgent.remainingDistance > arrivalThreshold)
            {
                yield return null;
            }
        }

        public void Stop()
        {
            if (_navigationAgent.isOnNavMesh)
            {
                _navigationAgent.ResetPath();
            }
        }
    }
}
