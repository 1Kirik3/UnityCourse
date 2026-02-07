using UnityEngine;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private AudioClip _soundClip;
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound()
    {
        if (_audioSource != null && _soundClip != null)
        {
            _audioSource.PlayOneShot(_soundClip);
        }
    }
}
