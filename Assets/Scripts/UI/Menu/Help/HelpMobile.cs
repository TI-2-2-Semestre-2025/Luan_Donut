using UnityEngine;

public class HelpMobile : MonoBehaviour
{
    public void Help(bool open) 
    {
        bool click = true;
        if (click) Game_Manager.Instance.AudioManager.ClickSound();
        MenuMobile_Manager.Instance.Help(open);
    }
}
