using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(PlayerPocket))]
    public class PlayerCollector : MonoBehaviour
    {
        [SerializeField] private PlayerPocket _pocket;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_pocket == null)
                return;

            if (collision.TryGetComponent(out ICollectable collectable))
            {
                collectable.Collect(this);
            }
        }
    }
}

