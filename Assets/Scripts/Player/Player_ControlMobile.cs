using UnityEngine;

public class Player_ControlMobile : MonoBehaviour
{
    public float swipeDistanceMin = 25f;

    private Vector2 touchStart;
    private Vector2 touchEnd;

    private Player_Movement playerMovement;
    private Player_EntityStats _EntityStats;

    private void Start()
    {
        playerMovement = GetComponent<Player_Movement>();
        _EntityStats = GetComponent<Player_EntityStats>();
    }

    private void Update()
    {
        GetTouch();
    }

    private void GetTouch()
    {
        if (Input.touchCount == 4) Game_Manager.Instance.ChangeLevel();
        if (Input.touchCount == 5) _EntityStats.InfHealth();
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    touchStart = touch.position;
                    break;
                case TouchPhase.Ended:
                    touchEnd = touch.position;
                    TouchDetector();
                    break;
            }
            
        }
    }

    private void TouchDetector()
    {
        Vector2 touchPath = touchEnd - touchStart;

        //Swipe Check
        if (touchPath.magnitude > swipeDistanceMin)
        {
            Debug.Log("Swipe: " + touchPath.magnitude);

            float xDistance = touchPath.x;
            float yDistance = touchPath.y;

            if (Mathf.Abs(xDistance) >  Mathf.Abs(yDistance))
            {
                if (xDistance > 0)
                {
                    playerMovement.ChangeLane(1);
                }
                else
                {
                    playerMovement.ChangeLane(-1);
                }
            }else
            {
                if (yDistance > 0)
                {
                    playerMovement.Jump();
                }
                else
                {
                    playerMovement.Roll();
                }
            }
        }
    }
}
