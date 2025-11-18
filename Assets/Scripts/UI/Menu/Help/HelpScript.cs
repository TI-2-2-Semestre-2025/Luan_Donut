using UnityEngine;

public class HelpScript : MonoBehaviour
{
    public void Help(bool open)
    {
        Menu_Manager.Instance.Help(open);
    }
}
