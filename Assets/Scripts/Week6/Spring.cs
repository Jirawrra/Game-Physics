using UnityEngine;

public class Spring : MonoBehaviour
{
   [SerializeField] float springForce = 2f;

    private Rigidbody rb;
    private LineRenderer line;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, rb.position);
    }

}
