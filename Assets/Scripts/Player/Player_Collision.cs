using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    public int hp;
    void Start()
    {
        hp = 3;
        
        for (int i=0; i<hp; i++) Game_Manager.Instance.UI_HUD.AddHeart();
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
            Game_Manager.Instance.UI_HUD.RemoveHeart();
            hp--;
        }
    }

}
