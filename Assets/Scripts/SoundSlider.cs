using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider BGM_slider;
    public Slider SFX_slider;

    public void Bgm_Set()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(BGM_slider.value) * 20);

    }
    public void SFX_Set()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(SFX_slider.value) * 20);
    }
}
