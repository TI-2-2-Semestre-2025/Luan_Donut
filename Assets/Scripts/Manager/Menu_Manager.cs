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
            DontDestroyOnLoad(gameObject);
        } 
    }

    //Variables
    public UI_Pause pauseScript;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    
    void PauseGame()
    {
        if (pauseScript)
        {
            pauseScript.Pause();
        }
    }
    
    public void ExitGame() {
        Debug.Log("Saiu");
        Application.Quit();
    }

    // Change Scene
    public void ChangeSceneByIndex(int index) {
        StartCoroutine(I_ChangeSceneByIndex(index));
    }
    public void ChangeSceneByName(string sceneName) {
        StartCoroutine(I_ChangeSceneByName(sceneName));
        
    }

    IEnumerator I_ChangeSceneByIndex(int index) {
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(index);

        while (!sceneLoading.isDone) {
            yield return null;
        }
    }
    IEnumerator I_ChangeSceneByName(string sceneName) {
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(sceneName);

        while (!sceneLoading.isDone) {
            yield return null;
        }
    }


}
