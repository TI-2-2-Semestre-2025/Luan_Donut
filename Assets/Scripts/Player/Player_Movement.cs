using System;
using System.Collections;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public GameObject playerModel;
    public int lane = 0;
    public float playerMass;
    public float gravityForce;

    private float yMovement = 0;
    private bool roll = false;
    private bool changingLane = false;

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
            _entityStats.PlayerSound.JumpSound();
            _entityStats.animator.SetTrigger("Jump");
        }
    }

    private void Z_Movement()
    {
        _characterController.Move(_entityStats.speed * Time.deltaTime * transform.forward);
        if (_entityStats.speed < _entityStats.maxSpeed) _entityStats.speed += _entityStats.speedGain * Time.deltaTime;

        float animationSpeed = 1;
        animationSpeed += (_entityStats.speed / _entityStats.maxSpeed);
        if (animationSpeed <= 0) animationSpeed = 1;
        _entityStats.animator.SetFloat("RunSpeed", animationSpeed);
    }

    // 1 => Right / -1 => Left
    public void ChangeLane(int direction)
    {
        if (!changingLane)
        {
            lane += direction;
            if (lane is <= 1 and >= -1)
            {
                changingLane = true;
                StartCoroutine(I_ChangeLane(direction));
            }
            else lane -= direction;
        }

    }

    IEnumerator I_ChangeLane(int direction)
    {
        float laneOffset = Game_Manager.Instance.laneOffset;
        Vector3 startPosition = new Vector3(transform.position.x, 0, 0);
        Vector3 endPosition = startPosition + (direction * laneOffset * Vector3.right);


        _entityStats.PlayerSound.SwipeSound();
        float distanceTravelled = 0;
        while (distanceTravelled < 3)
        {
            Vector3 move = (laneOffset / _entityStats.changeLaneSeconds) * Time.deltaTime * direction * transform.right;
            _characterController.Move(move);
            distanceTravelled += Math.Abs(move.x);
            yield return new WaitForEndOfFrame();
        }
        _characterController.Move(new Vector3(endPosition.x, transform.position.y, transform.position.z) - transform.position);
        changingLane = false;

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
        int multi = 4;
        float defCenter = 0.94f;
        float defHeight = 1.69f;

        roll = true;
        _entityStats.PlayerSound.RollSound();
        _entityStats.animator.SetTrigger("StartRoll");

        yMovement -= _entityStats.jumpForce + gravityForce;
        _characterController.height = 0.2f;
        _characterController.center = new Vector3(0, 0.2f, 0);

        int quantity = 25;
        for (int i = 0; i < quantity; i++)
        {
            yield return new WaitForSeconds(_entityStats.rollSeconds / quantity);
            if (!roll) i = quantity;
        }

        _characterController.height = defHeight;
        _characterController.center = new Vector3(0, defCenter, 0);

        playerModel.transform.localScale = new Vector3(1, 1, 1);
        _entityStats.PlayerSound.RollSound();
        _entityStats.animator.SetTrigger("EndRoll");
        roll = false;
    }


    public void Hit()
    {
        _entityStats.speed = (_entityStats.speed - _entityStats.initialSpeed) / 1.5f + _entityStats.initialSpeed;
    }
}
