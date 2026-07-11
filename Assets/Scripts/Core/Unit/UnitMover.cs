using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Core.Unit
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class UnitMover : MonoBehaviour
    {
        private NavMeshAgent _navigationAgent;

        public bool HasReachedDestination(float thresholdDistance)
        {
            if (_navigationAgent.pathPending || _navigationAgent.pathStatus == NavMeshPathStatus.PathInvalid)
            {
                return false;
            }

            return _navigationAgent.remainingDistance <= thresholdDistance;
        }

        private void Awake()
        {
            _navigationAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 destination)
        {
            _navigationAgent.SetDestination(destination);
        }

        public void Stop()
        {
            _navigationAgent.ResetPath();
        }
    }
}
