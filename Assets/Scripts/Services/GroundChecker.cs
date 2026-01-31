using UnityEngine;

namespace Assets.Scripts.Services
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private float _groundCheckRadius = 0.5f;
        [SerializeField] private LayerMask _groundLayer;

        public bool IsGrounded { get; private set; }

        private void FixedUpdate()
        {
            CheckGrounded();
        }

        private void CheckGrounded()
        {
            IsGrounded = Physics2D.OverlapCircle(transform.position, _groundCheckRadius, _groundLayer);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _groundCheckRadius);
        }
    }
}

