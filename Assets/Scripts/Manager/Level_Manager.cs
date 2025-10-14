using UnityEngine;
using System.Collections;

public class Level_Manager : MonoBehaviour
{
    public static Level_Manager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public float distance = 1000;
    public float playerDistance = 0;
    public float terrainBlocksMulti = 5;
    public int powerUpChance;
    public int coinChance;

    public GameObject GroundCollider;
    public GameObject[] powerUps;
    public GameObject[] terrainBlocks;
    public GameObject[] scenarioBlocks;

    private int terrainBlocksDistance = 25;
    private float terrainBlocksGenerated = 1;
    private GameObject player;

    private void Start()
    {
        Game_Manager.Instance.LevelManager = this;
    }

    private void Update()
    {
        GenerateStreet();
        GroundColliderControl();

        try
        {
            DistanceCheck();
        }catch {}
    }

    private void GenerateScenario()
    {
        int index = Random.Range(0, scenarioBlocks.Length);
        GameObject ScenarioRight = Instantiate(scenarioBlocks[index]);
        GameObject ScenarioLeft = Instantiate(scenarioBlocks[index]);
        
        ScenarioRight.transform.position = Vector3.zero;
        ScenarioRight.transform.Translate(0, 0, terrainBlocksDistance * terrainBlocksGenerated);
        
        ScenarioLeft.transform.position = Vector3.zero;
        ScenarioLeft.transform.Translate(0, 0, terrainBlocksDistance * terrainBlocksGenerated);
        ScenarioLeft.transform.localScale = new Vector3(-1, 1, 1);
        
        
        StartCoroutine(I_DeleteMap(ScenarioLeft));
        StartCoroutine(I_DeleteMap(ScenarioRight));
    }

    private void GenerateStreet()
    {
        if (playerDistance + (terrainBlocksMulti * terrainBlocksDistance) >= (terrainBlocksDistance * terrainBlocksGenerated))
        {
            int index = Random.Range(0, terrainBlocks.Length);
            int genPowerUp = Random.Range(1, 101);
            int genCoins = Random.Range(1, 101);
            
            GameObject terrain = Instantiate(terrainBlocks[index]);
            terrain.transform.position = Vector3.zero;
            terrain.transform.Translate(0, 0, terrainBlocksDistance * terrainBlocksGenerated);
            StreetBehavior terrainScript = terrain.GetComponent<StreetBehavior>();
            if (genPowerUp <= powerUpChance)
            {
                GameObject go = powerUps[Random.Range(0, powerUps.Length)]; 
                terrainScript.GeneratePowerUp(go);
            }
            if (genCoins <= coinChance) terrainScript.GenerateCoin();
            GenerateScenario();
            
            terrainBlocksGenerated++;

            StartCoroutine(I_DeleteMap(terrain));
        }
    }

    private IEnumerator I_DeleteMap(GameObject obj)
    {
        yield return new WaitForSeconds(20);
        Destroy(obj);
    }

    private void DistanceCheck()
    {
        Game_Manager.Instance.UI_HUD.ChangeDistanceSlider(playerDistance, distance);
        if (playerDistance >= distance)
        {
            Game_Manager.Instance.ChangeSceneByIndex(2);
        }
    }

    private void GroundColliderControl()
    {
        Vector3 playerPosition = Game_Manager.Instance.Player.transform.position;

        GroundCollider.transform.position = new Vector3(playerPosition.x, 0, playerPosition.z);
    }
}
