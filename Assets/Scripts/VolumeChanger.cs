using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeChanger : MonoBehaviour
{
    private const float MinVolume = -80f;
    private const float MaxVolume = 20f;

    [SerializeField] private AudioMixerHandler _audioMixer;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = MinVolume;
        _slider.maxValue = MaxVolume;
    }

    private void OnEnable()
    {
        _audioMixer.VolumeReseted += ChangeVolume;
    }

    private void OnDisable()
    {
        _audioMixer.VolumeReseted -= ChangeVolume;
    }

    public void ChangeVolume(float value)
    {
        _audioMixerGroup.audioMixer.SetFloat(_audioMixerGroup.name, value);
        _slider.value = value;
    }
}