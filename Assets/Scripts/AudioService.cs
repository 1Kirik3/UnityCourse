using UnityEngine;
using UnityEngine.Audio;

public class AudioService
{
    private readonly AudioMixer _audioMixer;

    public AudioService(AudioMixer audioMixer)
    {
        _audioMixer = audioMixer;
    }

    public void SetVolume(string parameterName, float volume)
    {
        float dB = ConvertToDecibels(volume);
        _audioMixer.SetFloat(parameterName, dB);
    }

    public float GetVolume(string parameterName)
    {
        if (_audioMixer.GetFloat(parameterName, out float dB))
        {
            return ConvertFromDecibels(dB);
        }

        return AudioConsts.DefaultVolume;
    }

    public void ToggleMasterVolume(bool isMuted)
    {
        if (isMuted)
        {
            _audioMixer.SetFloat(AudioConsts.MasterVolume, AudioConsts.MinDecibels);
        }
        else
        {
            _audioMixer.SetFloat(AudioConsts.MasterVolume, AudioConsts.MaxDecibels);
        }
    }

    private float ConvertToDecibels(float volume)
    {
        return volume > AudioConsts.VolumeThreshold ? Mathf.Log10(volume) * 20 : AudioConsts.MinDecibels;
    }

    private float ConvertFromDecibels(float dB)
    {
        return Mathf.Pow(10, dB / 20);
    }

}
