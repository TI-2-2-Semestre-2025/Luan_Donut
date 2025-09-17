using UnityEngine;

public class Player_EntityStats : MonoBehaviour
{
    public float changeLaneSeconds;
    public float rollSeconds;
    public float defSpeed;
    public float speed;
    public float speedGain;
    public float jumpForce;
    
    public void Start()
    {
        speed = defSpeed;
        Game_Manager.Instance.Player = this;
    }
}
