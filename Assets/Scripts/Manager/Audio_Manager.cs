using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;

public class Audio_Manager : MonoBehaviour
{
    public AudioMixer masterMixer;
    public AudioSource Click;
    void Start()
    {
        Game_Manager.Instance.MasterVolume = masterMixer;
        Game_Manager.Instance.AudioManager = this;
        
    }

    public void ClickSound()
    {
        Click.Play(); 
    }

}
