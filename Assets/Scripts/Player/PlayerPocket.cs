using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerPocket : MonoBehaviour
    {
        private int _coinsValue;

        public void InreaseCoinsValue(int value)
        {
            _coinsValue += value;
        }
    }
}

