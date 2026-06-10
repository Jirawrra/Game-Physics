using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveDistance = 3f;
    public float speed = 2f;

    public Vector3 Velocity { get; private set; }

    private Rigidbody rb;
    private Vector3 startPos;
    private Vector3 lastPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        float offset = Mathf.PingPong(Time.time * speed, moveDistance * 2f) - moveDistance;

        Vector3 targetPos = startPos + transform.right * offset;

        Velocity = (targetPos - lastPosition) / Time.fixedDeltaTime;

        rb.MovePosition(targetPos);

        lastPosition = targetPos;
    }
}