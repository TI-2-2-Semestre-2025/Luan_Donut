using UnityEngine;

public class Player_EntityStats : MonoBehaviour
{
    public float hp;
    public float changeLaneSeconds;
    public float rollSeconds;
    public float initialSpeed;
    public float speed;
    public float maxSpeed;
    public float speedGain;
    public float jumpForce;

    public int coins;

    public Player_Collectables PlayerCollectables;
    
    public void Start()
    {
        speed = initialSpeed;
        Game_Manager.Instance.Player = this;
    }
}
