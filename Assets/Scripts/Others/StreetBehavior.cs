using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class StreetBehavior : MonoBehaviour
{
    public GameObject[] powerUpsLocation;
    public GameObject[] coins;

    private void Awake()
    {
        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].SetActive(false);
        }
    }

    public void GeneratePowerUp(GameObject PowerUp)
    {
        GameObject powerUpGO = Instantiate(PowerUp);
        GameObject powerUpPosition = powerUpsLocation[Random.Range(0, powerUpsLocation.Length)];
        powerUpGO.transform.position = powerUpPosition.transform.position;
    }

    public void GenerateCoin()
    {
        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].SetActive(true);
        }
    }
}
