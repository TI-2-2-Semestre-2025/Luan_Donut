using UnityEngine;

public class Player_EntityStats : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public float changeLaneSeconds;
    public float rollSeconds;
    public float initialSpeed;
    public float speed;
    public float maxSpeed;
    public float speedGain;
    public float jumpForce;
    public int coins;
    public int coinsToBonus;
    public int coinsBonusSeconds;


    public Player_Sound PlayerSound;
    public Player_Collectables PlayerCollectables;
    public Player_Movement PlayerMovement;

    public void Start()
    {
        speed = initialSpeed;
        Game_Manager.Instance.Player = this;
    }
    
    public void InfHealth()
    {
        hp = 1000;
        for (int i=0; i<3; i++)
        {
            try { Game_Manager.Instance.UI_HUD.RemoveHeart(); } catch { }
        }
    }
}
