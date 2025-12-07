using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UI_Options : MonoBehaviour
{
    public AudioMixer master;

    public Slider sliderSoundEffects;
    public Slider sliderMusic;
    private void Start()
    {
        Game_Manager.Instance.UI_Options = this;
        gameObject.SetActive(false);

        float volumeEffects = PlayerPrefs.GetFloat("VolumeEffects");
        float volumeMusic = PlayerPrefs.GetFloat("VolumeMusic");
        float dbEffects = volumeEffects <= 0.001f ? -80f : Mathf.Log10(volumeEffects) * 20;
        float dbMusic = volumeMusic <= 0.001f ? -80f : Mathf.Log10(volumeMusic) * 20;
        master.SetFloat("SoundsEffects", dbEffects);
        master.SetFloat("Music", dbMusic);
        sliderSoundEffects.value = volumeEffects;
        sliderMusic.value = volumeMusic;
    }

    public void ChangeEffectsVolume()
    {
        float volume = sliderSoundEffects.value;
        float db = volume <= 0.001f ? -80f : Mathf.Log10(volume) * 20;
        master.SetFloat("SoundsEffects", db);
        PlayerPrefs.SetFloat("VolumeEffects", volume);
    }

    public void ChangeMusicVolume()
    {
        float volume = sliderMusic.value;
        float db = volume <= 0.001f ? -80f : Mathf.Log10(volume) * 20;
        master.SetFloat("Music", db);
        PlayerPrefs.SetFloat("VolumeMusic", volume);
    }

    public void OpenOptions()
    {
        gameObject.SetActive(true);
    }

    public void CloseOptions()
    {
        gameObject.SetActive(false);
    }
}
