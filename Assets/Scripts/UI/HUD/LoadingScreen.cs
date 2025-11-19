using System.Drawing;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public float seconds;
    private float sizeImage;

    private RectTransform rect;
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        sizeImage = rect.sizeDelta.x;
    }

    void Update()
    {
        float finalSize = (sizeImage / seconds) * Time.deltaTime;
        rect.sizeDelta -= new Vector2(finalSize,finalSize);

        if (rect.sizeDelta.x < 0)
        {
            Destroy(gameObject);
        }
    }
}
