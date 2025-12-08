using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Manager : MonoBehaviour
{
    public static Menu_Manager Instance { get; private set; }
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

    public GameObject CreditsPrefab;
    public GameObject CreditsThirdPrefab;
    public GameObject HelpPrefab;
    public GameObject PlayButton;


    private bool optionsOpened;
    private GameObject CreditsGO;
    private GameObject CreditsThirdGO;
    private GameObject HelpGO;

    private void Start()
    {
        Game_Manager.Instance.MenuManager = this;
    }

    public void Play(bool click=false)
    {
        if (click) Game_Manager.Instance.AudioManager.ClickSound();
        StartCoroutine(I_Play(PlayButton));
    }

    IEnumerator I_Play(GameObject button)
    {
        button.GetComponent<Animator>().SetTrigger("TriggerPlay");
        yield return new WaitForSeconds(1f);
        Game_Manager.Instance.ChangeSceneByIndex(1);
    }

    public void OpenOptions(bool click=false)
    {
        if (click) Game_Manager.Instance.AudioManager.ClickSound();
        Game_Manager.Instance.UI_Options.OpenOptions();
    }

    public void Credits(bool value)
    {
        if (value)
        {
            bool click = true;
            if (click) Game_Manager.Instance.AudioManager.ClickSound();
            CreditsGO = Instantiate(CreditsPrefab);
        }else
        {
            Destroy(CreditsGO);
        }
    }

    public void ThirdCredits(bool value)
    {
        if (value)
        {
            bool click = true;
            if (click) Game_Manager.Instance.AudioManager.ClickSound();
            CreditsThirdGO = Instantiate(CreditsThirdPrefab);
        }else
        {
            Destroy(CreditsThirdGO);
        }
    }

    public void Help(bool open)
    {
        if (open)
        {
            bool click = true;
            if (click) Game_Manager.Instance.AudioManager.ClickSound();
            HelpGO = Instantiate(HelpPrefab);
        }
        else Destroy(HelpGO);
    }
     
    public void ExitGame()
    {
        Game_Manager.Instance.ExitGame();
    }


    //Temp for final screens
    public void ChangeSceneByIndex(int index)
    {
        Game_Manager.Instance.ChangeSceneByIndex(index);
    }

    
}
