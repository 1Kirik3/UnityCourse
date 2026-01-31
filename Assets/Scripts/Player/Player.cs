using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;

        private void FixedUpdate()
        {
            _playerMovement.HandleMovement();
            _playerMovement.HandleJump();
        }

    }
}
