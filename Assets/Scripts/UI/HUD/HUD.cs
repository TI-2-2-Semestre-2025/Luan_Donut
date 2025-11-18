using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    
    public Slider coinMeterSlider;
    public TextMeshProUGUI coinMeterText; 
    public Image coinMeterSliderImage;
    public GameObject cointMeterParent;

    public GameObject houseIcon;
    public TextMeshProUGUI DistanceMeter;
    private bool distanceMeterActive;
    public Slider distanceSlider;
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
        
        
        coinMeterText.color = Color.yellow;
        coinMeterSliderImage.color = Color.yellow;
        cointMeterParent.SetActive(false);
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

    // ====================== Coin Meter Mechanics =================================

    public void ChangeCoinValue(float value, bool rainbow=false, int seconds=0)
    {
        coinMeterSlider.value = value;
        if (value > 0) cointMeterParent.SetActive(true);
        if (value == 0) cointMeterParent.SetActive(false);

        if (rainbow)
        {
            StartCoroutine(RainbowCoinMeter(seconds));
            StartCoroutine(PumpCoinMeter(seconds));
        }
    }

    private IEnumerator RainbowCoinMeter(int seconds)
    {
        float rainbowSpeed = 4;

        float hue = 0;
        float saturation = 0.9f;
        float value = 0.9f;
        Color color;
        
        for (float i=0; i<seconds; i+=Time.deltaTime)
        {
            color = Color.HSVToRGB(hue, saturation, value);
            hue += 0.1f * Time.deltaTime * rainbowSpeed;
            if (hue >= 1) hue = 0;

            coinMeterText.color = color;
            coinMeterSliderImage.color = color;
            yield return new WaitForEndOfFrame();
        }
        coinMeterText.color = Color.yellow;
        coinMeterSliderImage.color = Color.yellow;
    }

    private IEnumerator PumpCoinMeter(int seconds)
    {
        float pumpSpeed = 4;
        float pumpMultiply = 0.15f;
        float size;

        for (float i=0; i<seconds*pumpSpeed; i+=Time.deltaTime*pumpSpeed)
        {
            size = (Mathf.Sin(i)+1) * pumpMultiply;

            cointMeterParent.transform.localScale = Vector3.one + new Vector3(size, size, size);
            yield return new WaitForEndOfFrame();
        }
        cointMeterParent.transform.localScale = Vector3.one;
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
