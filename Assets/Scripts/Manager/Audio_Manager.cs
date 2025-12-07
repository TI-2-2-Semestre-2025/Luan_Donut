using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;

public class Audio_Manager : MonoBehaviour
{
    public AudioMixer masterMixer;

    void Start()
    {
        Game_Manager.Instance.MasterVolume = masterMixer;

        
    }

}
