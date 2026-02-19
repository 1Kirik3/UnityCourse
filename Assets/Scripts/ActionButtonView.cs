using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ActionButtonView : MonoBehaviour
{
    [SerializeField] protected float _amount = 10f;
    [SerializeField] private Button _button;

    protected Health _health;

    public void Initialize(Health health)
    {
        _health = health;
        _button.onClick.AddListener(HandleClick);
    }

    private void OnDestroy()
    {
        _button?.onClick.RemoveListener(HandleClick);
    }

    protected abstract void HandleClick();
}
