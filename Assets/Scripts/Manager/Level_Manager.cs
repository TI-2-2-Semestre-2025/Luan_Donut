using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

    //  attributes level-based changes
    public float fogQuantity;
    public float distance = 1000;
    public int powerUpChance;
    public int coinChance;
    public int level;
    
    
    public float playerDistance = 0;
    public int terrainBlocksDistance;
    public float terrainBlocksMulti = 5;
    
    public GameObject GroundCollider;
    public GameObject[] powerUps;
    public GameObject[] terrainBlocks;
    public GameObject[] scenarioBlocks;
    
    private float terrainBlocksGenerated = 1;
    private GameObject player;

    private void Start()
    {
        Game_Manager.Instance.LevelManager = this;
        Game_Manager.Instance.currentLevel = level;
    }

    private void Update()
    {
        //Scenario Generator

        
        if (playerDistance + (terrainBlocksMulti * terrainBlocksDistance) >= (terrainBlocksDistance * terrainBlocksGenerated)) MapGeneration();
        

        //if (terrainBlocksGenerated < (distance / terrainBlocksDistance)+1) MapGeneration();
        
        GroundColliderControl();
        try
        {
            DistanceCheck();
        }catch {}
    }

    public void MapGeneration()
    {
        GenerateStreet();
        GenerateScenario();
        terrainBlocksGenerated++;
    }
    

    private void GenerateStreet()
    {
        GameObject[] terrainsToUse = terrainBlocks;
        
        int index = Random.Range(0, terrainBlocks.Length);
        int genPowerUp = Random.Range(1, 101);
        int genCoins = Random.Range(1, 101);
        
        GameObject terrain = Instantiate(terrainsToUse[index]);
        terrain.transform.position = Vector3.zero;
        terrain.transform.Translate(0, 0, terrainBlocksDistance * terrainBlocksGenerated);
        StreetBehavior terrainScript = terrain.GetComponent<StreetBehavior>();
        if (genPowerUp <= powerUpChance)
        {
            GameObject go = powerUps[Random.Range(0, powerUps.Length)]; 
            terrainScript.GeneratePowerUp(go);
        }
        if (genCoins <= coinChance) terrainScript.GenerateCoin();
        
        StartCoroutine(I_DeleteMap(terrain));
    }
    private void GenerateScenario()
    {
        int index1 = Random.Range(0, scenarioBlocks.Length);
        int index2 = Random.Range(0, scenarioBlocks.Length);
        GameObject ScenarioRight = Instantiate(scenarioBlocks[index1]);
        GameObject ScenarioLeft = Instantiate(scenarioBlocks[index2]);
        
        ScenarioRight.transform.position = Vector3.zero;
        ScenarioRight.transform.Translate(0, 0, terrainBlocksDistance * terrainBlocksGenerated);
        
        ScenarioLeft.transform.position = Vector3.zero;
        ScenarioLeft.transform.Translate(0, 0, terrainBlocksDistance * terrainBlocksGenerated);
        ScenarioLeft.transform.localScale = new Vector3(-1, 1, 1);
        
        
        StartCoroutine(I_DeleteMap(ScenarioLeft));
        StartCoroutine(I_DeleteMap(ScenarioRight));
    }

    private IEnumerator I_DeleteMap(GameObject obj)
    {
        bool waiting = true;
        while (waiting)
        {
            yield return new WaitForSeconds(2);
            if (playerDistance-80 > obj.transform.position.z) waiting = false;
        }
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
