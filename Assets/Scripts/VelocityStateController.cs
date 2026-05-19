using UnityEngine;

public class VelocityStateController : MonoBehaviour
{
    
    public enum MovementState {Idle, Walk, Run}

    public MovementState currentState;

    public float walkSpeed;
    public float runSpeed;

    private float currentVelocity;

    void Update()
    {

            HandleInput();
            ApplyVelocity();
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentState = MovementState.Run;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentState = MovementState.Walk;
        }
        else
        {
            currentState = MovementState.Idle;   
        }
    }

    void ApplyVelocity()
    {
        switch (currentState)
        {
            case MovementState.Idle:
                currentVelocity = 0f;
                break;
            case MovementState.Walk:
                currentVelocity = walkSpeed;
                break;
            case MovementState.Run:
                currentVelocity = runSpeed;
                break;
        }
        transform.position += transform.forward * currentVelocity * Time.deltaTime;
    }
}

