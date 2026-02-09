using UnityEngine;
using UnityEngine.Audio;

public class AudioInitializer : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioSource _backgroundMusicSource;
    [SerializeField] private VolumeSliderController[] _sliderControllers;
    [SerializeField] private SoundToggle _toggleController;

    private AudioService _audioService;

    private void Start()
    {
        InitializeServices();
        InitializeBackgroundMusic();
        InitializeSliders();
        InitializeToggle();
    }

    private void InitializeServices()
    {
        _audioService = new AudioService(_audioMixer);
    }

    private void InitializeBackgroundMusic()
    {
        _backgroundMusicSource.loop = true;
        _backgroundMusicSource.Play();
    }

    private void InitializeSliders()
    {
        foreach (var sliderController in _sliderControllers)
        {
            sliderController.Initialize(_audioService);
        }
    }

    private void InitializeToggle()
    {
        _toggleController.Initialize(_audioService);
    }
}
