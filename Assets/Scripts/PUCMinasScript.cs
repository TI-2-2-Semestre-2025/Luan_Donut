using UnityEngine;

public class PUCMinasScript : MonoBehaviour
{
    private float count = 0;
    private float seconds = 5f; 

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count >= seconds)
        {
            Destroy(gameObject);
        }
    }
}
