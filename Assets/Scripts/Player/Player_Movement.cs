using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player_Movement : MonoBehaviour
{
    public float laneDistance;
    public float rollSeconds;
    public float speed;

    public float gravity;
    public float jumpForce;

    private bool isJump;
    private int lane=0;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Gravity();
        characterController.Move(speed * Time.deltaTime * transform.forward);
            
        //Left / Right
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
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
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

    private void Gravity()
    {
        Vector3 velocity = transform.up;

        if (characterController.isGrounded)
        {
            if(isJump)
            {
                velocity.y *= jumpForce;
                isJump = false;

                characterController.Move(velocity);
            }
        }else
        {
            velocity.y = gravity * Time.deltaTime;

            characterController.Move(-velocity);
        }
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
