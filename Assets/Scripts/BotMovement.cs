using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class BotMovement : MonoBehaviour
    {
        [Header("Speed & Rotation")]
        [SerializeField] private float moveSpeed = 4.5f;
        [SerializeField] private float rotationSpeed = 10.0f;

        [SerializeField] private Rigidbody rb;

        public float MoveSpeed => moveSpeed;

        public void MoveTowards(Vector3 direction)
        {
            if (direction == Vector3.zero) 
                return;

            Vector3 nextPosition = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(nextPosition);
        }

        public void RotateTowards(Vector3 direction)
        {
            if (direction == Vector3.zero) 
                return;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion smoothedRotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);

            rb.MoveRotation(smoothedRotation);
        }
    }
}
