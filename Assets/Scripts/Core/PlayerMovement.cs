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

    private float boostSpeed;
    private float boostWalkingDistance;

    private Vector2 moveVector;

    private bool isMove = false;
    private bool boost = false;

    private void FixedUpdate()
    {
        if (ControlManager.Instance.IsClassicControl())
        {
            if (joystickClassic.Horizontal != 0 || joystickClassic.Vertical != 0)
            {
                if (boost)
                {
                    moveVector = new Vector2(joystickClassic.Horizontal * boostSpeed, joystickClassic.Vertical * boostSpeed);
                    rigidbody.velocity = moveVector;
                
                    currentDistance += boostWalkingDistance;
                    distanceBar.SetWalkingDistance(boostWalkingDistance);
                }
                else
                {
                    moveVector = new Vector2(joystickClassic.Horizontal * speed, joystickClassic.Vertical * speed);
                    rigidbody.velocity = moveVector;

                    currentDistance += walkingDistance;
                    distanceBar.SetWalkingDistance(walkingDistance);
                }
            }
        }

        if (ControlManager.Instance.IsExpertControl())
        {
            if (isMove)
            {
                rigidbody.velocity = moveVector;

                if (boost)
                {
                    currentDistance += boostWalkingDistance;
                    distanceBar.SetWalkingDistance(boostWalkingDistance);
                }
                else
                {
                    currentDistance += walkingDistance;
                    distanceBar.SetWalkingDistance(walkingDistance);
                }
            }
        }

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
        if (boost)
        {
            moveVector = new Vector2(rigidbody.velocity.x, boostSpeed);
        }
        else
        {
            moveVector = new Vector2(rigidbody.velocity.x, speed);
        }
    }

    public void MovePlayerDown()
    {
        isMove = true;
        if (boost)
        {
            moveVector = new Vector2(rigidbody.velocity.x, -boostSpeed);
        }
        else
        {
            moveVector = new Vector2(rigidbody.velocity.x, -speed);
        }
    }

    public void MovePlayerLeft()
    {
        isMove = true;
        if (boost)
        {
            moveVector = new Vector2(-boostSpeed, rigidbody.velocity.y);
        }
        else
        {
            moveVector = new Vector2(-speed, rigidbody.velocity.y);
        }
    }

    public void MovePlayerRight()
    {
        isMove = true;
        if (boost)
        {
            moveVector = new Vector2(boostSpeed, rigidbody.velocity.y);
        }
        else
        {
            moveVector = new Vector2(speed, rigidbody.velocity.y);
        }
    }

    public void SetPlayerMovement(float currentSpeed, float currentWalkingDistance, float currentMaxDistance)
    {
        speed = currentSpeed;
        walkingDistance = currentWalkingDistance;
        maxDistance = currentMaxDistance;
        
        distanceBar.SetSliderInStart(currentDistance, maxDistance);
    }

    public void SetPlayerBoostMovement(float currentBoostSpeed, float currentBoostWalkingDistance)
    {
        boostSpeed = currentBoostSpeed;
        boostWalkingDistance = currentBoostWalkingDistance;
    }

    public void ActivateBoost()
    {
        boost = !boost;
    }
}
