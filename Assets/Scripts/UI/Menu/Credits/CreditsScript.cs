using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public void Credits(bool open)
    {
        bool click = true;
        if (click) Game_Manager.Instance.AudioManager.ClickSound();
        Menu_Manager.Instance.Credits(open);
    }

    public void ThirdCredits(bool open)
    {
        bool click = true;
        if (click) Game_Manager.Instance.AudioManager.ClickSound();
        Menu_Manager.Instance.ThirdCredits(open);
    }
}
