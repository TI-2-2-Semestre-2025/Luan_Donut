using UnityEngine;

public class HelpMobile : MonoBehaviour
{
    public void Help(bool open) 
    {
        MenuMobile_Manager.Instance.Help(open);
    }
}
