using System;
using UnityEngine;

namespace Assets.Scripts.Core.Base
{
    public class BaseStorage : MonoBehaviour
    {
        public event Action<int> ResourcesChanged;

        private int _collectedResourcesAmount = 0;

        public int CurrentAmount => _collectedResourcesAmount;


        private void Start()
        {
            ResourcesChanged?.Invoke(_collectedResourcesAmount);
        }

        public void AddResource()
        {
            _collectedResourcesAmount++;
            ResourcesChanged?.Invoke(_collectedResourcesAmount);
        }

        public bool TrySpend(int amount)
        {
            if (_collectedResourcesAmount < amount)
            {
                return false;
            }

            _collectedResourcesAmount -= amount;
            ResourcesChanged?.Invoke(_collectedResourcesAmount);

            return true;
        }
    }
}
