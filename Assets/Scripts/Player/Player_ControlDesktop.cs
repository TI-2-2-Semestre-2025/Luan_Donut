using UnityEngine;

public class Player_ControlDesktop : MonoBehaviour
{
    private Player_Movement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<Player_Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerMovement.ChangeLane(direction: 1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerMovement.ChangeLane(direction: -1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerMovement.Roll();
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.Jump();
        }
        
        //Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Game_Manager.Instance.PauseChange();
        }
    }
}
