using UnityEngine;
using UnityEngine.UI;

public class UI_HUD : MonoBehaviour
{
    public Slider distanceSlider; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Game_Manager.Instance.UI_HUD = this;
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
}
