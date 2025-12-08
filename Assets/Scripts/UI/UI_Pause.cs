using UnityEngine;

public class UI_Pause : MonoBehaviour
{
    public bool OptionsOpened = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Game_Manager.Instance.UI_Pause = this;
        gameObject.SetActive(false);
    }

    public void ChangeVisibility(bool value)
    {
        gameObject.SetActive(value);
    }

    public void Continue(bool click=false)
    {
        if (click) Game_Manager.Instance.AudioManager.ClickSound();
        Game_Manager.Instance.PauseGame(false);
    }
    
    public void ExitToMenu()
    {
        Game_Manager.Instance.ChangeSceneByIndex(0);
    }

    public void OpenOptions(bool click=false)
    {
        if (click) Game_Manager.Instance.AudioManager.ClickSound();
        Game_Manager.Instance.UI_Options.OpenOptions();
        OptionsOpened = true;
    }

    public void CloseOptions(bool click=false)
    {
        if (click) Game_Manager.Instance.AudioManager.ClickSound();
        Game_Manager.Instance.UI_Options.CloseOptions();
        OptionsOpened = false;
    }
}
