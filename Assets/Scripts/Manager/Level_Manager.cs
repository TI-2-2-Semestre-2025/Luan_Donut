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
    public float distanceRemaining;

    private GameObject player;

    private void Start()
    {
        Game_Manager.Instance.LevelManager = this;
        
        player = Game_Manager.Instance.Player;
    }

    private void Update()
    {
        if (player != null)
        {
            DistanceCheck();
        }
    }

    private void DistanceCheck()
    {
        distanceRemaining = distance - player.transform.position.z;
        if (distanceRemaining <= 0)
        {
            Menu_Manager.Instance.ChangeSceneByIndex(0);
        }
    }
}
