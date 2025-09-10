using System;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    public GameObject[] obstaclesHandle;

    private GameObject[] obstacles;
    private Level_Manager levelManager;

    private void Start()
    {
        levelManager = Game_Manager.Instance.LevelManager;
        obstacles = levelManager.obstacles;
        
        GenerateObstacles();
    }

    private void GenerateObstacles()
    {
        for (int i = 0; i < obstaclesHandle.Length; i++)
        {
            int random = UnityEngine.Random.Range(0, 101);
            if (random <= levelManager.obsChance)
            {
                int obsIndex = UnityEngine.Random.Range(0, obstacles.Length);
                GameObject obs = Instantiate(obstacles[obsIndex], gameObject.transform);
                obs.transform.position = obstaclesHandle[i].transform.position;
            }
        }
    }
}
