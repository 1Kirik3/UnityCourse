using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class StepClimber : MonoBehaviour
    {
        [Header("Step Detection")]
        [SerializeField] private float stepHeight = 0.4f;
        [SerializeField] private float stepRayDistance = 0.6f;
        [SerializeField] private float lowerRayOffset = 0.1f;

        [Header("Step Response")]
        [SerializeField] private float stepSmooth = 5.0f;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void TryStep(Vector3 moveDirection)
        {
            if (moveDirection == Vector3.zero) return;

            Vector3 lowerOrigin = rb.position + Vector3.up * lowerRayOffset;
            Vector3 upperOrigin = rb.position + Vector3.up * stepHeight;

            bool hasObstacleBelow = Physics.Raycast(lowerOrigin, moveDirection, stepRayDistance);
            bool hasClearanceAbove = !Physics.Raycast(upperOrigin, moveDirection, stepRayDistance);

            if (hasObstacleBelow && hasClearanceAbove)
            {
                Vector3 targetPosition = rb.position + Vector3.up * (stepSmooth * Time.fixedDeltaTime);
                rb.MovePosition(targetPosition);
            }
        }
    }
}

