using UnityEngine;

public class Olho : MonoBehaviour
{
    
    public GameObject Player;
    void Start()
    {

    }


    void Update()
    {
        transform.LookAt(Player.transform);
    }
}
