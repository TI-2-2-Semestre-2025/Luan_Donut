using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    public bool CoinMagnetActive = false;
    public GameObject CoinMagnetGO;
    private Player_EntityStats _entityStats;

    void Start()
    {
        _entityStats = GetComponent<Player_EntityStats>();
        StartCoroutine(waitUI());
    }
    
    void Update()
    {
        if (CoinMagnetActive) CoinMagnetGO.transform.position = _entityStats.gameObject.transform.position;
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
            if (_entityStats.hp == 1000) return;
            gameObject.GetComponent<Player_Movement>().Hit();
            Game_Manager.Instance.UI_HUD.RemoveHeart();
            _entityStats.hp--;

            if (_entityStats.hp <= 0)
            {
                Game_Manager.Instance.ChangeSceneByIndex(3);
            }
        }
    }

    public void CoinMagnetCreate()
    {
        if (CoinMagnetActive) return;

        CoinMagnetGO = new GameObject();
        CoinMagnetGO.tag = "CoinMagnet";
        SphereCollider collider = CoinMagnetGO.AddComponent<SphereCollider>();
        collider.isTrigger = true;
        collider.radius = 12;
        Rigidbody rg = CoinMagnetGO.AddComponent<Rigidbody>();
        rg.useGravity = false;
        
        CoinMagnetActive = true;
    }
    
    public void CoinMagnetDestroy()
    {
        CoinMagnetActive = false;
        Destroy(CoinMagnetGO);
    }
}
