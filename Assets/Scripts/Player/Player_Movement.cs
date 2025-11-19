using System;
using System.Collections;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public GameObject playerModel;
    public int lane=0;
    public float playerMass;
    public float gravityForce;

    private float yMovement = 0;
    private bool roll = false;
    
    private CharacterController _characterController;
    private Player_EntityStats _entityStats;
    

    private void Start()
    {
        _entityStats = GetComponent<Player_EntityStats>();
        _characterController = GetComponent<CharacterController>();

        _entityStats.PlayerMovement = this;
    }

    private void Update()
    {
        Z_Movement();
        Gravity();
        Level_Manager.Instance.playerDistance = transform.position.z;
    }

    private void Gravity()
    {
        if (_characterController.isGrounded) yMovement = 0;
        yMovement += -(gravityForce * playerMass * Time.deltaTime);
        
        _characterController.Move(yMovement * Time.deltaTime * transform.up);
    }
    
    public void Jump()
    {
        if (transform.position.y <= 0.5f)
        {
            roll = false;
            yMovement = 0;
            yMovement = _entityStats.jumpForce + gravityForce;  
        }
    }

    private void Z_Movement()
    {
        _characterController.Move(_entityStats.speed * Time.deltaTime * transform.forward);
        if (_entityStats.speed < _entityStats.maxSpeed) _entityStats.speed += _entityStats.speedGain * Time.deltaTime;
    }

    // 1 => Right / -1 => Left
    public void ChangeLane(int direction)
    {
        lane += direction;
        if (lane is <= 1 and >= -1)
        {
            //Change Lane Mechanic
            StartCoroutine(I_ChangeLane(direction));
        }else lane -= direction;
    }
    
    IEnumerator I_ChangeLane(int direction)
    {
        float laneOffset = Game_Manager.Instance.laneOffset;
        Vector3 startPosition = new Vector3(transform.position.x, 0, 0);
        Vector3 endPosition = startPosition + (direction * laneOffset * Vector3.right);

        
        float distanceTravelled = 0;
        while (distanceTravelled < 3)
        {
            Vector3 move = (laneOffset / _entityStats.changeLaneSeconds) * Time.deltaTime * direction * transform.right;
            _characterController.Move(move);
            distanceTravelled += Math.Abs(move.x);
            yield return new WaitForEndOfFrame();
        }
        _characterController.Move(new Vector3(endPosition.x, transform.position.y, transform.position.z) - transform.position);
        
    }

    public void Roll()
    {
        if (!roll)
        {
            StartCoroutine(I_Roll());
        }
    }
    
    private IEnumerator I_Roll()
    {
        int multi = 3;
        float defHeight = _characterController.height;
        Vector3 defCenter = _characterController.center;
        
        roll = true;
        _characterController.height /= multi;
        _characterController.center -= new Vector3(0, _characterController.height/multi, 0);
        yMovement -= _entityStats.jumpForce + gravityForce;
        playerModel.transform.localScale = new Vector3(1, 0.5f, 1);

        int quantity = 25;
        for (int i=0; i<quantity; i++)
        {
            yield return new WaitForSeconds(_entityStats.rollSeconds / quantity);
            if (!roll) i = quantity;
        }
        
        _characterController.height = defHeight;
        _characterController.center = defCenter;
        playerModel.transform.localScale = new Vector3(1, 1, 1);
        roll = false;
    }
    
    
    public void Hit()
    {
        _entityStats.speed = (_entityStats.speed-_entityStats.initialSpeed)/1.5f + _entityStats.initialSpeed;
    }
}
