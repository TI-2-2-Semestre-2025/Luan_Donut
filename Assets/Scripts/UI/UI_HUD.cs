using UnityEngine;

public class UI_HUD : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Game_Manager.Instance.UI_HUD = this;
    }

    public void Pause()
    {
        Game_Manager.Instance.UI_Pause.Pause();
    }
}
