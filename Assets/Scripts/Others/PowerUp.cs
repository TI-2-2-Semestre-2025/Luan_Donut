using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public int coinValue;
    
    public bool isHealth;
    public bool isCoin;
    
    private Renderer rend;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
    
    private void OnTriggerEnter(Collider Trigger)
    {
        if (Trigger.gameObject.CompareTag("Player"))
        {
            if (isHealth) Health(Player: Trigger.gameObject);
            if (isCoin) Coin(Player: Trigger.gameObject);
        }
    }
    
    private void Health(GameObject Player)
    {
        Player.GetComponent<Player_EntityStats>().PlayerCollectables.AddLife();
        Destroy(gameObject);
    }

    private void Coin(GameObject Player)
    {
        Player.GetComponent<Player_EntityStats>().PlayerCollectables.AddCoin(coinValue);
        Destroy(gameObject);
    }
}
