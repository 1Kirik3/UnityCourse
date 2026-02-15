using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DamageButtonView : MonoBehaviour
{
    [SerializeField] private float _damageAmount = 10f;
    [SerializeField] private Button _button;

    private HealthViewModel _viewModel;

    public void Initialize(HealthViewModel viewModel)
    {
        _viewModel = viewModel;
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _viewModel.ApplyDamage(_damageAmount);
    }

    private void OnDestroy()
    {
        _button?.onClick.RemoveListener(OnButtonClick);
    }
}