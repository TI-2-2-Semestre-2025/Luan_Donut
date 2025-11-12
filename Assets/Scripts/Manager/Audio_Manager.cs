using UnityEngine;
using System.Collections.Generic;

public class Audio_Manager : MonoBehaviour
{
    Dictionary<string, AudioClip> audios;

    void Start()
    {
        Game_Manager.Instance.AudioManager = this;

        Debug.Log(audios["Play"]);
        
    }


}
