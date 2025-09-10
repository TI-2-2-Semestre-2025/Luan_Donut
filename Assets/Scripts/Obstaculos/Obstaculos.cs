using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
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
