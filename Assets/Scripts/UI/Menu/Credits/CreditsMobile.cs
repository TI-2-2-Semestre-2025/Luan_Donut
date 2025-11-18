using UnityEngine;

public class CreditsMobile : MonoBehaviour
{
    public void Credits(bool open)
    {
        MenuMobile_Manager.Instance.Credits(open);
    }
}
