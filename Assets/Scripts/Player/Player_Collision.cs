using System.Collections;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    private Player_EntityStats _entityStats;
    
    void Start()
    {
        _entityStats = GetComponent<Player_EntityStats>();
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < _entityStats.hp; i++) Game_Manager.Instance.UI_HUD.AddHeart();
    }

    
    void FixedUpdate()
    {
        if (_entityStats.hp <= 0)
        {
            Game_Manager.Instance.ChangeSceneByIndex(0);
        }
    }

    private void OnTriggerEnter(Collider Trigger)

    {
        // Damage
        if (Trigger.gameObject.tag == "Obstaculo")
        {
            gameObject.GetComponent<Player_Movement>().Hit();
            Game_Manager.Instance.UI_HUD.RemoveHeart();
            _entityStats.hp--;
        }
        
        // Life Power Up
        if (Trigger.gameObject.tag == "Vida")
        {
            if (_entityStats.hp < 3)
            {
                Game_Manager.Instance.UI_HUD.AddHeart();
                _entityStats.hp++;
            }
        }
    }

}
