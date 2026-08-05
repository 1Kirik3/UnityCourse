using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class StepClimber : MonoBehaviour
    {
        [Header("Step Detection")]
        [SerializeField] private float _stepHeight = 0.4f;
        [SerializeField] private float _stepRayDistance = 0.6f;
        [SerializeField] private float _lowerRayOffset = 0.1f;

        [Header("Step Response")]
        [SerializeField] private float _stepSmooth = 5.0f;

        [SerializeField] private Rigidbody _rigidbody;

        public void TryStep(Vector3 moveDirection)
        {
            if (moveDirection == Vector3.zero) 
                return;

            Vector3 lowerOrigin = _rigidbody.position + Vector3.up * _lowerRayOffset;
            Vector3 upperOrigin = _rigidbody.position + Vector3.up * _stepHeight;

            bool hasObstacleBelow = Physics.Raycast(lowerOrigin, moveDirection, _stepRayDistance);
            bool hasClearanceAbove = !Physics.Raycast(upperOrigin, moveDirection, _stepRayDistance);

            if (hasObstacleBelow && hasClearanceAbove)
            {
                Vector3 targetPosition = _rigidbody.position + Vector3.up * (_stepSmooth * Time.fixedDeltaTime);
                _rigidbody.MovePosition(targetPosition);
            }
        }
    }
}

