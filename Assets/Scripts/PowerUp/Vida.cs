using UnityEngine;

public class Vida : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider Trigger)

    {
        if (Trigger.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

    }
}
