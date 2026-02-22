using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.HealthPackage.Buttons
{
    [RequireComponent(typeof(Button))]
    public abstract class ActionButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] protected float Amount = 10f;

        protected Health.Health Health;

        public void Initialize(Health.Health health)
        {
            Health = health;
            _button.onClick.AddListener(HandleClick);
        }

        private void OnDestroy()
        {
            _button?.onClick.RemoveListener(HandleClick);
        }

        protected abstract void HandleClick();
    }
}


