using System;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float laneDistance;
    public float speed;
    
    private int lane=0;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigidbody.AddForce(speed * 100 * Time.deltaTime * transform.forward);
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeLane(direction: 1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeLane(direction: -1);
        }
    }
    
    // 1 => Right / -1 => Left
    void ChangeLane(int direction)
    {
        lane += direction;
        if (lane is <= 1 and >= -1)
        {
            transform.Translate(laneDistance * direction * transform.right);
        }else {lane -= direction;};
        Debug.Log(lane);
    }
}
