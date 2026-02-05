using Assets.Scripts.Player;
using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.CombatSystem
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private InputReader _input;
        [SerializeField] private PlayerAnimation _playerAnimation;

        [SerializeField] private float _cooldown; 
        
        private float _lastAttackTime;

        private void OnEnable()
        {
            _input.AttackPressed += Attack;
        }

        private void OnDisable()
        {
            _input.AttackPressed -= Attack;
        }

        private void Attack()
        {
            if (Time.time >= _lastAttackTime + _cooldown)
            {
                _playerAnimation.AnimateAttack();
                _lastAttackTime = Time.time;
            }
        }

    }
}
