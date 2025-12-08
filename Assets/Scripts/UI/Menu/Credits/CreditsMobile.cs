using UnityEngine;

public class CreditsMobile : MonoBehaviour
{
    public void Credits(bool open)
    {
        bool click = true;
        if (click) Game_Manager.Instance.AudioManager.ClickSound();
        MenuMobile_Manager.Instance.Credits(open);
    }
}
