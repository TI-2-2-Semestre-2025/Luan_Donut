using System.Collections;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    private Player_EntityStats _entityStats;
    
    void Start()
    {
        _entityStats = GetComponent<Player_EntityStats>();
        StartCoroutine(waitUI());
    }

    IEnumerator waitUI()
    {
        bool waiting = true;
        while (waiting)
        {
            try
            {
                for (int i = 0; i < _entityStats.hp; i++) Game_Manager.Instance.UI_HUD.AddHeart();
                waiting = false;
            }
            catch { }
            yield return new WaitForEndOfFrame();
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

            if (_entityStats.hp <= 0)
            {
                Game_Manager.Instance.ChangeSceneByIndex(3);
            }
        }
    }

}
