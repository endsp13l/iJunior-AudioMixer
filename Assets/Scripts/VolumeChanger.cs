using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class VolumeChanger : MonoBehaviour
{
   private const float MinVolume = -80f;
   private const float MaxVolume = 20f;
   private const float DefaultVolume = 0f;
   
   [SerializeField] private AudioMixerGroup _audioMixerGroup;
   
   private Slider _slider;
   
   private void Awake()
   {
      _slider = GetComponent<Slider>();
      _slider.minValue = MinVolume;
      _slider.maxValue = MaxVolume;
   }
   
   public void ChangeVolume(float value)
   {
      _audioMixerGroup.audioMixer.SetFloat(_audioMixerGroup.name, value);
   }
}
