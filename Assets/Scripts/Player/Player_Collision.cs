using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    public int hp;
    void Start()
    {
        hp = 3;
    }

    
    void FixedUpdate()
    {
        if (hp <= 0)
        {
            Game_Manager.Instance.ChangeSceneByIndex(0);
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
