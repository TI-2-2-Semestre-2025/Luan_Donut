using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_HUD : MonoBehaviour
{
    public Slider distanceSlider;
    public GameObject Heart;
    public GameObject HeartHandle;
    public List<GameObject> Hearts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Game_Manager.Instance.UI_HUD = this;
        StartCoroutine(I_InitialHeart());
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

    private IEnumerator I_InitialHeart()
    {
        while (true)
        {
            GameObject Player = Game_Manager.Instance.Player;
            if (Player != null)
            {
                int qtdHeart = Player.GetComponent<Player>().hp;
                Hearts = new List<GameObject>(qtdHeart);
                for (int i = 0; i < qtdHeart; i++)
                {
                    GameObject life = Instantiate(Heart, HeartHandle.transform);
                    Hearts.Add(life);
                }
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public void RemoveHeart(int qtd)
    {
        int heartToDestroy = Hearts.Count - 1;
        Destroy(Hearts[heartToDestroy]);
        Hearts.RemoveAt(heartToDestroy);
    }
}
