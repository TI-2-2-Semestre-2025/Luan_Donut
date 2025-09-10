using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player_Movement : MonoBehaviour
{
    public float laneDistance;
    public float rollSeconds;
    public float speed;
    public float jumpForce;

    private int lane=0;
    private bool isRoll=false;
    private Rigidbody rigidbody;
    private CapsuleCollider collider;

    private void Start()
    {
        Game_Manager.Instance.Player = gameObject;

        laneDistance = Game_Manager.Instance.laneOffset;
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        rigidbody.AddForce(speed * 100 * Time.deltaTime * transform.forward);
    }

    // 1 => Right / -1 => Left
    public void ChangeLane(int direction)
    {
        lane += direction;
        if (lane is <= 1 and >= -1)
        {
            transform.Translate(laneDistance * direction * transform.right);
        }else {lane -= direction;};
    }

    public void Jump()
    {
        if (transform.position.y <= 1.1)
        {
            rigidbody.AddForce(jumpForce * transform.up, ForceMode.Impulse);
        }
    }

    public void Roll()
    {
        if (!isRoll)
        {
            isRoll = true;
            StartCoroutine(I_Roll());
        }
    }

    private IEnumerator I_Roll()
    {
        float defHeight = collider.height;
        Vector3 defCenter = collider.center;

        collider.height /= 2;
        collider.center -= new Vector3(0, collider.height/2, 0);
        yield return new WaitForSeconds(rollSeconds);
        collider.height = defHeight;
        collider.center = defCenter;
        isRoll = false;
    }
}
