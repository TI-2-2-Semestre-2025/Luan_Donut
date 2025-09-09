using UnityEngine;

public class UI_HUD : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Menu_Manager.Instance.hudScript = this;
    }

    public void Pause()
    {
        Menu_Manager.Instance.pauseScript.Pause();
    }
}
