using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    protected HealthViewModel ViewModel;

    public void Initialize(HealthViewModel viewModel)
    {
        ViewModel = viewModel;
        ViewModel.StateChanged += OnStateChanged;
        OnStateChanged();
    }

    private void OnDestroy()
    {
        if (ViewModel != null)
            ViewModel.StateChanged -= OnStateChanged;
    }

    protected abstract void OnStateChanged();
}
