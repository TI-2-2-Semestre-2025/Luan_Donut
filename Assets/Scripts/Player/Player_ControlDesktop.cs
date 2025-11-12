using UnityEngine;

public class Player_ControlDesktop : MonoBehaviour
{
    private Player_Movement playerMovement;
    private Player_EntityStats _EntityStats;

    private void Start()
    {
        playerMovement = GetComponent<Player_Movement>();
        _EntityStats = GetComponent<Player_EntityStats>();
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
        
        //Game Cheats
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            Game_Manager.Instance.ChangeLevel(Game_Manager.Instance.currentLevel+1);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _EntityStats.InfHealth();
        }
    }
}
