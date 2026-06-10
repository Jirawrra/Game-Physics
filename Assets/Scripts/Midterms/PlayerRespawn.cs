using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 checkpointPosition;
    public float fallLimit = -20f;

    void Start()
    {
        checkpointPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < fallLimit)
        {
            transform.position = checkpointPosition;
        }
    }
}
