using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManagerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
