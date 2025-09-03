using System.Collections;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float laneDistance;
    public float rollSeconds;
    public float speed;
    
    private int lane=0;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        characterController.Move(speed * Time.deltaTime * transform.forward);
            
        //Basics
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeLane(direction: 1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeLane(direction: -1);
        }
        //Roll
        if (Input.GetKeyDown(KeyCode.S))
        {
            Roll();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Jump
        }
    }
    
    // 1 => Right / -1 => Left
    private void ChangeLane(int direction)
    {
        lane += direction;
        if (lane is <= 1 and >= -1)
        {
            characterController.enabled = false;
            transform.Translate(laneDistance * direction * transform.right);
            characterController.enabled = true;
        }else {lane -= direction;};
    }

    private void Roll()
    {
        StartCoroutine(I_Roll());
    }

    private IEnumerator I_Roll()
    {
        float defHeight = characterController.height;
        Vector3 defCenter = characterController.center;
        
        characterController.height /= 2;
        characterController.center -= new Vector3(0, characterController.height/2, 0);
        yield return new WaitForSeconds(rollSeconds);
        characterController.height = defHeight;
        characterController.center = defCenter;
    }
}
