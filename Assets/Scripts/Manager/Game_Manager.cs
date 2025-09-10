using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance { get; private set; }
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

    public bool isPaused;
    public float laneOffset = 2.4f;

    public Level_Manager LevelManager;
    public Menu_Manager MenuManager;

    public UI_HUD UI_HUD;
    public UI_Pause UI_Pause;

    public GameObject Player;

    public void PauseGame(bool pause)
    {
        isPaused = pause;
        UI_Pause.ChangeVisibility(isPaused);

        if (isPaused) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Debug.Log("Saiu");
        Application.Quit();
    }

    // Change Scene
    public void ChangeSceneByIndex(int index)
    {
        Time.timeScale = 1;
        StartCoroutine(I_ChangeSceneByIndex(index));
    }
    public void ChangeSceneByName(string sceneName)
    {
        Time.timeScale = 1;
        StartCoroutine(I_ChangeSceneByName(sceneName));
    }

    IEnumerator I_ChangeSceneByIndex(int index)
    {
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(index);

        while (!sceneLoading.isDone)
        {
            yield return null;
        }
    }
    IEnumerator I_ChangeSceneByName(string sceneName)
    {
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(sceneName);

        while (!sceneLoading.isDone)
        {
            yield return null;
        }
    }
}
