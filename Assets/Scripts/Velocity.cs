using UnityEngine;

public class Velocity : MonoBehaviour
{
    public float velocity = 3f;

    void Update()
    {
        transform.position += transform.right * velocity * Time.deltaTime;
    }
}
