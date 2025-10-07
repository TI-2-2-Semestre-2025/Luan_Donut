using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject canvasOptions_pf;

    private GameObject canvasOptions;
    private bool optionsOpened;

    private void Start()
    {
        Game_Manager.Instance.MenuManager = this;
    }

    public void ChangeSceneByIndex(int index)
    {
        Game_Manager.Instance.ChangeSceneByIndex(index);
    }
     
    public void ExitGame()
    {
        Game_Manager.Instance.ExitGame();
    }

    public void OpenOptions()
    {
        canvasOptions = GameObject.Instantiate(canvasOptions_pf);
    }

    public void CloseOptions()
    {
        Destroy(canvasOptions);
    }
}
