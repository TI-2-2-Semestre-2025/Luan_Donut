using UnityEngine;

public class Player_EntityStats : MonoBehaviour
{
    public float changeLaneSeconds;
    public float rollSeconds;
    public float speed;
    public float speedGain;
    public float jumpForce;
    
    public void Start()
    {
        Game_Manager.Instance.Player = this;
    }
}
