using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _recoveryRate = 0.2f;
    [SerializeField] private AudioSource _audioSource;

    private float _maxVolume = 1f;
    private float _minVolume = 0f;
    private float _targetVolume;

    private void Awake()
    {
        _audioSource.volume = _minVolume;
        _targetVolume = _minVolume;
    }

    private void Start()
    {
        _audioSource.Play();
    }

    private void Update()
    {
        if (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _recoveryRate * Time.deltaTime);
        }
    }

    public void IncreaseVolume()
    {
        _targetVolume = _maxVolume;
    }

    public void DecreaseVolume()
    {
        _targetVolume = _minVolume;
    }
}
