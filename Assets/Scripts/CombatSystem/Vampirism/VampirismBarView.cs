using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CombatSystem.Vampirism
{
    public class VampirismBarView : MonoBehaviour
    {
        [SerializeField] private VampirismTimer _vampirismTimer;
        [SerializeField] private Slider _slider;

        private void OnEnable()
        {
            _vampirismTimer.Updated += OnStateChanged;
            OnStateChanged();
        }

        private void OnDisable()
        {
            if (_vampirismTimer != null)
                _vampirismTimer.Updated -= OnStateChanged;
        }

        private void OnStateChanged()
        {
            if (_vampirismTimer.IsActive == false && _vampirismTimer.IsOnCooldown == false)
                _slider.value = 1f;
            else
                _slider.value = _vampirismTimer.Progress;
        }
    }
}

