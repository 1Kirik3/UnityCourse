using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class BulletRemover : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Bullet bullet))
            {
                bullet.gameObject.SetActive(false);
            }
        }
    }
}
