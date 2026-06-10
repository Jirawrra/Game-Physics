using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float jumpForce = 6f;

    public Transform cameraTransform;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private bool isGrounded;

    private ObstacleMovement currentPlatform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        moveDirection = (cameraForward * moveZ + cameraRight * moveX).normalized;

        // Rotate player toward movement direction
        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 velocity = moveDirection * moveSpeed;

        if (currentPlatform != null)
        {
            velocity += currentPlatform.Velocity;
        }

        velocity.y = rb.linearVelocity.y;

        rb.linearVelocity = velocity;
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;

        currentPlatform = collision.gameObject.GetComponent<ObstacleMovement>();
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;

        if (collision.gameObject.GetComponent<ObstacleMovement>())
        {
            currentPlatform = null;
        }
    }

}