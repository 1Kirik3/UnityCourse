using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _recoveryRate = 0.2f;
    [SerializeField] private AudioSource _audioSource;

    private float _maxVolume = 1f;
    private float _minVolume = 0f;
    private float _targetVolume;
    private Coroutine _volumeCoroutine;

    private void Awake()
    {
        _audioSource.volume = _minVolume;
        _targetVolume = _minVolume;
    }

    private void Start()
    {
        _audioSource.Play();
    }

    public void IncreaseVolume()
    {
        StartChangingVolume(_maxVolume);
    }

    public void DecreaseVolume()
    {
        StartChangingVolume(_minVolume);
    }

    private void StartChangingVolume(float targetVolume)
    {
        if (_volumeCoroutine != null)
        {
            StopCoroutine(_volumeCoroutine);
        }

        _volumeCoroutine = StartCoroutine(ChangeVolumeRoutine(targetVolume));
    }

    private IEnumerator ChangeVolumeRoutine(float targetVolume)
    {
        while (Mathf.Approximately(_audioSource.volume, targetVolume) == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }

}
