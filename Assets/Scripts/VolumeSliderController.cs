using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioParameter _parameter;

    private AudioService _audioService;

    public void Initialize(AudioService audioService)
    {
        _audioService = audioService;

        InitializeSlider();
    }

    private void InitializeSlider()
    {
        _slider.value = AudioConsts.DefaultVolume;
        _audioService?.SetVolume(_parameter.ToString(), AudioConsts.DefaultVolume);

        _slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float volume)
    {
        _audioService.SetVolume(_parameter.ToString(), volume);
    }

    private void OnDestroy()
    {
        _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }

}
