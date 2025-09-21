using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public Color objColor;
    public float slowMotionSeconds;
    
    public bool isSlowMotion;
    public bool isHealth;
    
    private Renderer rend;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
    
    private void OnTriggerEnter(Collider Trigger)
    {
        if (Trigger.gameObject.tag == "Player")
        {
            if (isHealth) Health();
        }
    }
    
    private void Health()
    {
        Destroy(gameObject);
    }
}
