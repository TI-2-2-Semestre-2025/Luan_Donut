using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public void Credits(bool open)
    {
        Menu_Manager.Instance.Credits(open);
    }

    public void ThirdCredits(bool open)
    {
        Menu_Manager.Instance.ThirdCredits(open);
    }
}
