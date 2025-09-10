using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp;
    void Start()
    {
        hp = 3;
    }

    
    void FixedUpdate()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject); Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider Trigger)

    {
        if (Trigger.gameObject.tag == "Obstaculo")
        {

            hp--;
        }
    }

}
