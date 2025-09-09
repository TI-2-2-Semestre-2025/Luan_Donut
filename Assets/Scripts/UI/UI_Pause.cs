using UnityEngine;

public class UI_Pause : MonoBehaviour
{
    public bool isPaused=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Game_Manager.Instance.UI_Pause = this;
        gameObject.SetActive(false);
    }

    public void Pause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
        
    }
    
    public void ExitToMenu()
    {
        Game_Manager.Instance.ChangeSceneByIndex(0);
    }
}
