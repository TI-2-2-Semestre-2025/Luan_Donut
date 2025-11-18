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


    private bool optionsOpened;
    private GameObject CreditsGO;
    private GameObject CreditsThirdGO;
    private GameObject HelpGO;

    private void Start()
    {
        Game_Manager.Instance.MenuManager = this;
    }

    public void Play(GameObject Button)
    {
        StartCoroutine(I_Play(Button));
    }

    IEnumerator I_Play(GameObject button)
    {
        button.GetComponent<Animator>().SetTrigger("TriggerPlay");
        yield return new WaitForSeconds(1f);
        Game_Manager.Instance.ChangeSceneByIndex(1);
    }

    public void OpenOptions()
    {
        Game_Manager.Instance.UI_Options.OpenOptions();
    }

    public void Credits(bool value)
    {
        if (value)
        {
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
            CreditsThirdGO = Instantiate(CreditsThirdPrefab);
        }else
        {
            Destroy(CreditsThirdGO);
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


    //Temp for final screens
    public void ChangeSceneByIndex(int index)
    {
        Game_Manager.Instance.ChangeSceneByIndex(index);
    }

    
}
