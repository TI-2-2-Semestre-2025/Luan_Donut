using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public int coinValue;
    public int coinMagnetSeconds;
    
    public bool isHealth;
    public bool isCoin;
    public bool isCoinMagnet;
    
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
        if (Trigger.gameObject.CompareTag("CoinMagnet"))
        {
            if (isCoin) StartCoroutine(I_CoinMagnetAnimation(Game_Manager.Instance.Player.gameObject));
            return;
        }
        if (Trigger.gameObject.CompareTag("Player"))
        {
            if (isHealth) Health(Player: Trigger.gameObject);
            if (isCoin) Coin(Player: Trigger.gameObject);
            if (isCoinMagnet) CoinMagnet(Player: Trigger.gameObject);
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


    // ================== Coin Magnet ==============================
    private void CoinMagnet(GameObject Player)
    {
        StartCoroutine(I_CoinMagnet(Player));
    }

    private IEnumerator I_CoinMagnet(GameObject Player)
    {
        Player_Collision PC = Player.GetComponent<Player_Collision>();
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;

        if (!PC.CoinMagnetActive)
        {
            PC.CoinMagnetCreate();
            Game_Manager.Instance.UI_HUD.CoinMagnetBuff(coinMagnetSeconds);
            yield return new WaitForSeconds(coinMagnetSeconds);
            PC.CoinMagnetDestroy();
        }
        Destroy(gameObject);
    }

    //Pikcup coins animation
    private IEnumerator I_CoinMagnetAnimation(GameObject player)
    {

        float seconds = 1f;

        for (float i=0; i<1; i+=Time.deltaTime*seconds)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, player.transform.position, i);
            yield return new WaitForEndOfFrame();
        }
    }
} 
