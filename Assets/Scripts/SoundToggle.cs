using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] private Button _toggleButton;

    private AudioService _audioService;
    private bool _isMuted = false;

    private void OnDisable()
    {
        _toggleButton.onClick.RemoveListener(OnToggleClicked);
    }

    public void Initialize(AudioService audioService)
    {
        _audioService = audioService;
        InitializeButton();
    }

    private void InitializeButton()
    {
        _toggleButton.onClick.AddListener(OnToggleClicked);
    }

    private void OnToggleClicked()
    {
        _isMuted = !_isMuted;
        _audioService?.ToggleMasterVolume(_isMuted);
    }

}
