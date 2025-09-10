using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp;
    void Start()
    {
        Game_Manager.Instance.Player = this.gameObject;
        hp = 3;
    }

    
    void FixedUpdate()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject); Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider Trigger)

    {
        if (Trigger.gameObject.tag == "Obstaculo")
        {
            Game_Manager.Instance.UI_HUD.RemoveHeart(1);
            hp--;
        }
    }

}
