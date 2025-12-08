using UnityEngine;

public class HelpScript : MonoBehaviour
{
    public void Help(bool open)
    {
        bool click = true;
        if (click) Game_Manager.Instance.AudioManager.ClickSound();
        Menu_Manager.Instance.Help(open);
    }
}
