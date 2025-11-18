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

    // =================== Hit ==========================

    private void OnTriggerEnter(Collider Trigger)
    {
        // Damage
        if (Trigger.gameObject.tag == "Obstaculo")
        {
            if (_entityStats.hp == 1000) return;
            gameObject.GetComponent<Player_Movement>().Hit();
            FlashPLayer(2);
            Immortal(2);
            Game_Manager.Instance.UI_HUD.RemoveHeart();
            _entityStats.hp--;

            if (_entityStats.hp <= 0)
            {
                Game_Manager.Instance.ChangeSceneByIndex(3);
            }
        }
    }

    public void FlashPLayer(int sec)
    {
        StartCoroutine(I_FlashPlayer(sec));
    }

    private IEnumerator I_FlashPlayer(int sec)
    {
        MeshRenderer[] meshs = GetComponentsInChildren<MeshRenderer>();
        
        for (int i = 0; i < sec*2.5f; i++)
        {
            for (int j = 0; j < meshs.Length; j++) meshs[j].enabled = false;
            yield return new WaitForSeconds(0.2f);
            for (int j = 0; j < meshs.Length; j++) meshs[j].enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void Immortal(int sec)
    {
        StartCoroutine(I_Immortal(sec));
    }

    IEnumerator I_Immortal(int sec)
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Obstacles"), true);
        yield return new WaitForSeconds(sec);
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Obstacles"), false);
    }

    // ============ Coin Magnet ====================

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
