using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private DistanceBar distanceBar;
    
    [SerializeField] 
    private Joystick joystickClassic;

    [SerializeField] 
    private Rigidbody2D rigidbody;

    private float speed = 10;
    private float currentDistance = 0f;
    private float walkingDistance = .3f;
    private float maxDistance = 2000f;

    private Vector2 moveVector;

    private bool isMove = false;

    private void Start()
    {
        ControlManager.Instance.SetControlExpert(); 
        distanceBar.SetSliderInStart(currentDistance, maxDistance);
    }

    private void FixedUpdate()
    {
        if (ControlManager.Instance.IsClassicControl())
        {
            if (joystickClassic.Horizontal != 0 || joystickClassic.Vertical != 0)
            {
                moveVector = new Vector2(joystickClassic.Horizontal * speed, joystickClassic.Vertical * speed);
                rigidbody.velocity = moveVector;
            }
        }

        if (ControlManager.Instance.IsExpertControl())
        {
            if (isMove)
            {
                rigidbody.velocity = moveVector;
            }
        }
        
        currentDistance += walkingDistance;
        distanceBar.SetWalkingDistance(walkingDistance);

        if (currentDistance >= maxDistance)
        {
            GameManager.Instance.WinGame();
        }
    }

    public void Reset()
    {
        isMove = false;
    }

    public void MovePlayerUp()
    {
        isMove = true;
        moveVector = new Vector2(rigidbody.velocity.x, speed);
    }

    public void MovePlayerDown()
    {
        isMove = true;
        moveVector = new Vector2(rigidbody.velocity.x, -speed);
    }

    public void MovePlayerLeft()
    {
        isMove = true;
        moveVector = new Vector2(-speed, rigidbody.velocity.y);
    }

    public void MovePlayerRight()
    {
        isMove = true;
        moveVector = new Vector2(speed, rigidbody.velocity.y);
    }

}
