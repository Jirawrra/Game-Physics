using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HingeJoint))]
public class WreckingBall : MonoBehaviour
{
    public float boostForce = 30f;
    public float minSpeed = 1f;

    private Rigidbody rb;
    private HingeJoint hinge;

    private bool boostedThisPass;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
    }

    private void FixedUpdate()
    {
        float angle = hinge.angle;

        // Near center of swing
        if (Mathf.Abs(angle) < 5f)
        {
            if (!boostedThisPass)
            {
                if (Mathf.Abs(rb.angularVelocity.x) < minSpeed)
                {
                    rb.AddTorque(
                        Vector3.right *
                        Mathf.Sign(rb.angularVelocity.x == 0 ? 1 : rb.angularVelocity.x) *
                        boostForce,
                        ForceMode.Impulse
                    );
                }

                boostedThisPass = true;
            }
        }
        else
        {
            boostedThisPass = false;
        }
    }
}