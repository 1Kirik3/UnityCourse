using System.Collections;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Crook crook))
        {
            _alarm.IncreaseVolume();
            crook.StartExitRoutine();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Crook crook))
        {
            _alarm.DecreaseVolume();
        }
    }
}
