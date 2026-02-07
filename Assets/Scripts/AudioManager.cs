using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer _audioMixer;

    [Header("Sliders")]
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    private float _masterVolume = 1f;
    private bool _isMuted = false;

    void Start()
    {
        InitializeSliders();
    }

    void InitializeSliders()
    {
        _masterSlider.onValueChanged.AddListener(SetMasterVolume);
        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMasterVolume(float volume)
    {
        Debug.Log($"Velue is {volume}");

        _masterVolume = volume;

        if (!_isMuted)
        {
            _audioMixer.SetFloat(AudioConsts.MasterVolume, Mathf.Log10(volume) * 20);
        }
    }

    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat(AudioConsts.MusicVolume, Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        _audioMixer.SetFloat(AudioConsts.SFXVolume, Mathf.Log10(volume) * 20);
    }

    public void ToggleAllSounds()
    {
        _isMuted = !_isMuted;

        if (_isMuted)
        {
            _audioMixer.SetFloat(AudioConsts.MasterVolume, -80f);
        }
        else
        {
            SetMasterVolume(_masterVolume);
        }

    }
 
}
