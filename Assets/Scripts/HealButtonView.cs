using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HealButtonView : MonoBehaviour
{
    [SerializeField] private float _healAmount = 10f;
    [SerializeField] private Button _button;

    private HealthViewModel _viewModel;

    public void Initialize(HealthViewModel viewModel)
    {
        _viewModel = viewModel;
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _viewModel.ApplyHeal(_healAmount);
    }

    private void OnDestroy()
    {
        _button?.onClick.RemoveListener(OnButtonClick);
    }
}