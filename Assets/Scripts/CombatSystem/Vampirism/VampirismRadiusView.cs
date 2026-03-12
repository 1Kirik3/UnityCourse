using UnityEngine;

namespace Assets.Scripts.CombatSystem.Vampirism
{
    public class VampirismRadiusView : MonoBehaviour
    {
        [SerializeField] private VampirismTimer _vampirismTimer;
        [SerializeField] private VampirismArea _vampirismArea;

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
            if (_vampirismArea.gameObject.activeSelf != _vampirismTimer.IsActive)
                _vampirismArea.gameObject.SetActive(_vampirismTimer.IsActive);
        }
    }

}

