using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlarmTrigger _alarmTrigger;
    [SerializeField] private Alarm _alarm;

    private void OnEnable()
    {
        _alarmTrigger.CrookDetected += OnCrookDetected;
        _alarmTrigger.CrookLeft += OnCrookLeft;
    }

    private void OnDisable()
    {
        _alarmTrigger.CrookDetected -= OnCrookDetected;
        _alarmTrigger.CrookLeft -= OnCrookLeft;
    }

    private void OnCrookDetected(Crook crook)
    {
        _alarm.IncreaseVolume();
        crook.StartExitRoutine();
    }

    private void OnCrookLeft(Crook crook)
    {
        _alarm.DecreaseVolume();
    }

}
