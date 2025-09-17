using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player_Movement : MonoBehaviour
{
    public int lane=0;
    public float offset;
    private bool roll = false;
    
    private Rigidbody _rigidbody;
    private CapsuleCollider _collider;
    private Player_EntityStats _entityStats;
    public GameObject playerModel;

    private void Start()
    {
        _entityStats = GetComponent<Player_EntityStats>();
        
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        Z_Movement();

        Level_Manager.Instance.playerDistance = transform.position.z;
    }

    private void Z_Movement()
    {
        _rigidbody.AddForce(_entityStats.speed * 100 * Time.deltaTime * transform.forward);
        _entityStats.speed += _entityStats.speedGain * Time.deltaTime;
    }
    
    
    public void Hit()
    {
        _entityStats.speed = _entityStats.defSpeed;
        StartCoroutine(I_FlashPlayer());
    }

    private IEnumerator I_FlashPlayer()
    {
        Vector3 dposition = playerModel.transform.position;
        
        for (int i = 0; i < 4; i++)
        {
            playerModel.transform.Translate(Vector3.up * 1000);
            yield return new WaitForSeconds(0.35f);
            playerModel.transform.Translate(Vector3.up * -1000);
            yield return new WaitForSeconds(0.35f);
        }
    }

    // 1 => Right / -1 => Left
    public void ChangeLane(int direction)
    {
        lane += direction;
        if (lane is <= 1 and >= -1)
        {
            StartCoroutine(I_ChangeLane(direction));
            //transform.Translate(Game_Manager.Instance.laneOffset * direction * transform.right);
        }else lane -= direction;
    }

    IEnumerator I_ChangeLane(int direction)
    {
        float count = 0;
        while (count < _entityStats.changeLaneSeconds)
        {
            float offset = Game_Manager.Instance.laneOffset;
            transform.Translate(Time.deltaTime/_entityStats.changeLaneSeconds * offset * direction * transform.right);
            count += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
    }

    public void Jump()
    {
        if (transform.position.y <= 1.1)
        {
            _rigidbody.AddForce(_entityStats.jumpForce * transform.up, ForceMode.Impulse);
        }
    }

    public void Roll()
    {
        if (!roll)
        {
            roll = true;
            StartCoroutine(I_Roll());
        }
    }

    private IEnumerator I_Roll()
    {
        int multi = 3;
        float defHeight = _collider.height;
        Vector3 defCenter = _collider.center;

        _collider.height /= 3;
        _collider.center -= new Vector3(0, _collider.height/3, 0);
        playerModel.transform.Rotate(90,0,0);
        playerModel.transform.Translate(0,-offset,0, Space.World);
        
        yield return new WaitForSeconds(_entityStats.rollSeconds);
        
        playerModel.transform.Translate(0,offset,0, Space.World);
        playerModel.transform.Rotate(-90,0,0);
        _collider.height = defHeight;
        _collider.center = defCenter;
        roll = false;
    }
}
