using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeChanger : MonoBehaviour
{
    private const float MinSliderValue = 0.0001f;
    private const float MaxSliderValue = 1f;
    private const float VolumeRatio = 20f;

    [SerializeField] private AudioMixerHandler _audioMixer;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = MinSliderValue;
        _slider.maxValue = MaxSliderValue;
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
        _audioMixerGroup.audioMixer.SetFloat(_audioMixerGroup.name, Mathf.Log10(value) * VolumeRatio);
        _slider.value = value;
    }
}