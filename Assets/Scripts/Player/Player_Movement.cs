using System.Collections;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public int lane=0;
    public float gravityForce;
    private bool roll = false;
    
    private CharacterController _characterController;
    private Player_EntityStats _entityStats;
    public GameObject playerModel;

    private void Start()
    {
        _entityStats = GetComponent<Player_EntityStats>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Z_Movement();
        Gravity();
        Level_Manager.Instance.playerDistance = transform.position.z;
    }

    private void Gravity()
    {
        _characterController.Move(gravityForce * Time.deltaTime * -transform.up);
    }

    private void Z_Movement()
    {
        _characterController.Move(_entityStats.speed * Time.deltaTime * transform.forward);
        _entityStats.speed += _entityStats.speedGain * Time.deltaTime;
    }

    // 1 => Right / -1 => Left
    public void ChangeLane(int direction)
    {
        lane += direction;
        if (lane is <= 1 and >= -1)
        {
            float laneOffset = Game_Manager.Instance.laneOffset;
            _characterController.Move(direction * laneOffset * transform.right);
        }else lane -= direction;
    }
    
    /*
    IEnumerator I_ChangeLane(int direction)
    {
        float laneOffset = Game_Manager.Instance.laneOffset;
        Vector3 startPosition = new Vector3(transform.position.x, 0, 0);
        Vector3 endPosition = startPosition + (direction * laneOffset * transform.right);

        for (float i = 0; i < _entityStats.changeLaneSeconds; i += Time.deltaTime)
        {
            float t = i / _entityStats.changeLaneSeconds;
            Vector3 movement = Vector3.Lerp(startPosition, endPosition, t);
            Debug.Log(movement - transform.position);
            _characterController.Move(movement - transform.position);
            yield return new WaitForEndOfFrame();
        }
        _characterController.Move(endPosition - transform.position);
    }
    */

    public void Jump()
    {
        /*
        if (transform.position.y <= 1.1)
        {
            _characterController.AddForce(_entityStats.jumpForce * transform.up, ForceMode.Impulse);
        }*/
    }

    public void Roll()
    {
        /*
        if (!roll)
        {
            roll = true;
            StartCoroutine(I_Roll());
        }*/
    }
    /*

    private IEnumerator I_Roll()
    {
        int multi = 3;
        float defHeight = _collider.height;
        Vector3 defCenter = _collider.center;

        _collider.height /= multi;
        _collider.center -= new Vector3(0, _collider.height/multi, 0);
        playerModel.transform.Rotate(90,0,0);
        playerModel.transform.Translate(0,-offset,0, Space.World);
        
        yield return new WaitForSeconds(_entityStats.rollSeconds);
        
        playerModel.transform.Translate(0,offset,0, Space.World);
        playerModel.transform.Rotate(-90,0,0);
        _collider.height = defHeight;
        _collider.center = defCenter;
        roll = false;
    }*/
    
    
    public void Hit()
    {
        /*
        _entityStats.speed = (_entityStats.speed+_entityStats.defSpeed)/1.5f;
        StartCoroutine(I_FlashPlayer());*/
    }

    private IEnumerator I_FlashPlayer()
    {
        Vector3 dposition = playerModel.transform.position;
        
        for (int i = 0; i < 5; i++)
        {
            playerModel.transform.Translate(Vector3.up * 1000);
            yield return new WaitForSeconds(0.2f);
            playerModel.transform.Translate(Vector3.up * -1000);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
