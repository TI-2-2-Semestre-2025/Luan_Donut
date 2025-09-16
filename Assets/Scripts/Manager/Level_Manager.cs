using UnityEngine;

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
    public int obsChance = 30;

    public GameObject GroundCollider;
    public GameObject[] terrainBlocks;
    public GameObject[] obstacles;

    private int terrainBlocksDistance = 25;
    private float terrainBlocksGenerated = 0;
    private GameObject player;

    private void Start()
    {
        Game_Manager.Instance.LevelManager = this;
    }

    private void Update()
    {
        GenerateTerrain();
        GroundColliderControl();

        try
        {
            DistanceCheck();
        }
        catch
        {
        }
    }

    private void GenerateTerrain()
    {
        if (playerDistance + (terrainBlocksMulti * terrainBlocksDistance) >= (terrainBlocksDistance * terrainBlocksGenerated))
        {
            int index = Random.Range(0, terrainBlocks.Length);
            GameObject terrain = Instantiate(terrainBlocks[index]);
            terrain.transform.position = Vector3.zero;
            terrain.transform.Translate(0, 0, terrainBlocksDistance * terrainBlocksGenerated);

            terrainBlocksGenerated++;
        }
    }

    private void DistanceCheck()
    {
        Game_Manager.Instance.UI_HUD.ChangeDistanceSlider(playerDistance, distance);
        if (playerDistance >= distance)
        {
            Game_Manager.Instance.ChangeSceneByIndex(0);
        }
    }

    private void GroundColliderControl()
    {
        Vector3 playerPosition = Game_Manager.Instance.Player.transform.position;

        GroundCollider.transform.position = new Vector3(playerPosition.x, 0, playerPosition.z);
    }
}
