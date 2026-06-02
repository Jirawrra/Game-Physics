using UnityEngine;
using System.Collections;

public class ReleaseSpringJoint : MonoBehaviour
{
    private SpringJoint springJoint;

    void Start()
    {
        springJoint = GetComponent<SpringJoint>();

        if (springJoint != null)
        {
            StartCoroutine(ReleaseAfterDelay(2f));
        }
    }

    IEnumerator ReleaseAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(springJoint); // Removes the joint
    }
}
