using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerCombat _playerCombat;

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void FixedUpdate()
        {
            _playerMovement.HandleMovement();
            _playerMovement.HandleJump();
        }

    }
}
