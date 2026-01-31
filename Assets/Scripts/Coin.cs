using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    private const string CoinCollectedTrigger = "CoinCollected";

    [SerializeField] private Animator _animator;
    [SerializeField] private int _value;

    private bool _isCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isCollected) return;

        if (collision.TryGetComponent(out PlayerPocket pocket))
        {
            _isCollected = true;
            pocket.InreaseCoinsValue(_value);
            _animator.SetTrigger(CoinCollectedTrigger);
        }
    }

    public void DestroyOnCollect()
    {
        Destroy(gameObject);
    }
}
