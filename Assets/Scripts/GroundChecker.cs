using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _groundCheckRadius = 0.5f;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded {  get; private set; }

    private void Update()
    {
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        IsGrounded = Physics2D.OverlapCircle(transform.position, _groundCheckRadius, _groundLayer);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _groundCheckRadius);
    }
}
