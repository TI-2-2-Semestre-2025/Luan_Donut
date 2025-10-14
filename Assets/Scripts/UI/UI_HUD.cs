using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_HUD : MonoBehaviour
{
    public Slider distanceSlider;
    public TextMeshProUGUI CoinsText;
    public GameObject Heart;
    public GameObject HeartHandle;
    public List<GameObject> Hearts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Game_Manager.Instance.UI_HUD = this;
        Hearts = new List<GameObject>(capacity: 3);
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

    public void ChangeCoinValue(int value)
    {
        CoinsText.text = $"Coins: {value}";
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
}
