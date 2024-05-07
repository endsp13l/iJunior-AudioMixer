using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class AudioMixerHandler : MonoBehaviour
{
    private const string Master = nameof(Master);
    private const string Mute = nameof(Mute);
    private const string Unmute = nameof(Unmute);

    private const float MuteMixerLevel = -80f;
    private const float DefaultLevelValue = 0.8f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Button _muteButton;

    private bool _isMuted;
    private float _currentLevel;

    public event Action<float> VolumeReseted;

    public void ToggleMuting()
    {
        if (_isMuted == false)
            _audioMixer.GetFloat(Master, out _currentLevel);

        _isMuted = !_isMuted;
        _audioMixer.SetFloat(Master, _isMuted ? MuteMixerLevel : _currentLevel);
        
        _muteButton.GetComponentInChildren<TMP_Text>().text = _isMuted ? Unmute : Mute;
    }

    public void ResetVolume()
    {
        VolumeReseted?.Invoke(DefaultLevelValue);
    }
}