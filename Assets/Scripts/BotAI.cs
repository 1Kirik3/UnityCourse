using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BotMovement))]
    [RequireComponent(typeof(StepClimber))]
    public class BotAI : MonoBehaviour
    {
        [Header("Target & Distance")]
        [SerializeField] private Transform target;
        [SerializeField] private float stoppingDistance = 2.5f;

        [SerializeField] private BotMovement movement;
        [SerializeField] private StepClimber climber;

        private void FixedUpdate()
        {
            if (target == null) 
                return;

            Vector3 directionToTarget = CalculateFlatDirection(transform.position, target.position, out float flatDistance);

            if (directionToTarget == Vector3.zero) 
                return;

            movement.RotateTowards(directionToTarget);

            if (flatDistance > stoppingDistance)
            {
                movement.MoveTowards(directionToTarget);
                climber.TryStep(directionToTarget);
            }
        }

        private Vector3 CalculateFlatDirection(Vector3 current, Vector3 targetPos, out float distance)
        {
            Vector3 flatCurrent = new Vector3(current.x, 0f, current.z);
            Vector3 flatTarget = new Vector3(targetPos.x, 0f, targetPos.z);

            Vector3 direction = flatTarget - flatCurrent;
            distance = direction.magnitude;

            return distance > 0f ? direction / distance : Vector3.zero;
        }
    }
}
