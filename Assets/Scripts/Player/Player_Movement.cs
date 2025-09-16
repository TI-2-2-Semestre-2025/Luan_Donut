using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player_Movement : MonoBehaviour
{
    private int lane=0;
    private bool roll = false;
    
    private Rigidbody rigidbody;
    private CapsuleCollider collider;
    private Player_EntityStats _entityStats;
    public GameObject playerModel;

    private void Start()
    {
        _entityStats = GetComponent<Player_EntityStats>();
        
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        rigidbody.AddForce(_entityStats.speed * 100 * Time.deltaTime * transform.forward);
        _entityStats.speed += _entityStats.speedGain * Time.deltaTime;

        Level_Manager.Instance.playerDistance = transform.position.z;
    }

    // 1 => Right / -1 => Left
    public void ChangeLane(int direction)
    {
        lane += direction;
        if (lane is <= 1 and >= -1)
        {
            transform.Translate(Game_Manager.Instance.laneOffset * direction * transform.right);
        }else {lane -= direction;};
    }

    public void Jump()
    {
        if (transform.position.y <= 1.1)
        {
            rigidbody.AddForce(_entityStats.jumpForce * transform.up, ForceMode.Impulse);
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
        float offset = 0.3f;
        
        float defHeight = collider.height;
        Vector3 defCenter = collider.center;

        collider.height /= 2;
        collider.center -= new Vector3(0, collider.height/2, 0);
        playerModel.transform.Rotate(90,0,0);
        playerModel.transform.Translate(0,-offset,0, Space.World);
        
        yield return new WaitForSeconds(_entityStats.rollSeconds);
        
        playerModel.transform.Translate(0,offset,0, Space.World);
        playerModel.transform.Rotate(-90,0,0);
        collider.height = defHeight;
        collider.center = defCenter;
        roll = false;
    }
}
