using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private GameObject player;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
        player = Game_Manager.Instance.Player.gameObject;
    }

    void Update()
    {
        transform.position = originalPosition + new Vector3(0, 0, originalPosition.z - player.transform.position.z);
    }
}
