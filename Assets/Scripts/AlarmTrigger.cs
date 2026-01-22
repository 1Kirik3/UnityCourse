using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    public event Action<Crook> CrookDetected;
    public event Action<Crook> CrookLeft;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Crook crook))
        {
            CrookDetected?.Invoke(crook);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Crook crook))
        {
            CrookLeft?.Invoke(crook);
        }
    }
}
