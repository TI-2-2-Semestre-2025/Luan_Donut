using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMobile_Manager : MonoBehaviour
{
    public static MenuMobile_Manager Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this;
        } 
    }

    public GameObject PlayLoading;
    public GameObject CreditsPrefab;
    public GameObject HelpPrefab;
    

    private GameObject CreditsGO;
    private GameObject HelpGO;

    private void Start()
    {
        Game_Manager.Instance.MenuMobile_Manager = this;
    }

    public void Play()
    {
        PlayLoading.SetActive(true);
        Game_Manager.Instance.ChangeSceneByIndex(1);
    }

    public void Options(bool open)
    {
        if (open) Game_Manager.Instance.UI_Options.OpenOptions();
        else Game_Manager.Instance.UI_Options.CloseOptions();
    }

    public void Credits(bool open)
    {
        if (open)
        {
            CreditsGO = Instantiate(CreditsPrefab);
        }else
        {
            Destroy(CreditsGO);
        }
    }

    public void Help(bool open)
    {
        if (open) HelpGO = Instantiate(HelpPrefab);
        else Destroy(HelpGO);
    }

    public void ExitGame()
    {
        Game_Manager.Instance.ExitGame();
    }
    
}
