using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UI_HUD : MonoBehaviour
{
    public GameObject houseIcon;
    public TextMeshProUGUI DistanceMeter;
    private bool distanceMeterActive;
    public Slider distanceSlider;
    public Slider coinSlider;
    public GameObject CoinMagnet;
    public GameObject Heart;
    public GameObject HeartHandle;
    public List<GameObject> Hearts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Game_Manager.Instance.UI_HUD = this;
        Hearts = new List<GameObject>(capacity: 3);
        ChangeCoinValue(0);

        CoinMagnet.SetActive(false);

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 2)
        {
            houseIcon.SetActive(false);
            distanceSlider.gameObject.SetActive(false);
            DistanceMeter.gameObject.SetActive(true);
            distanceMeterActive = true;
        }
    }

    void Update()
    {
        if (distanceMeterActive) DistanceMeter.text = $"{Game_Manager.Instance.Player.transform.position.z:F0}m";
    }

    public void Pause()
    {
        Game_Manager.Instance.PauseGame(true);
    }

    public void ChangeDistanceSlider(float value, float maxValue)
    {
        float finalValue = value / maxValue;

        distanceSlider.value = finalValue;
    }

    public void ChangeCoinValue(float value)
    {
        coinSlider.value = value;
    }

    public void AddHeart()
    {
        if (Hearts.Count <= 3) Hearts.Add(Instantiate(Heart, HeartHandle.transform));
    }

    public void RemoveHeart()
    {
        int heartToDestroy = Hearts.Count - 1;
        Destroy(Hearts[heartToDestroy]);
        Hearts.RemoveAt(heartToDestroy);
    }

    public void CoinMagnetManage(bool active=false)
    {
        CoinMagnet.SetActive(active);
    }
}
