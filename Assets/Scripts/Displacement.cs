using UnityEngine;
using System.Collections;

public class Displacement : MonoBehaviour
{
    [SerializeField] private float dis;
    [SerializeField] private float duration;

    void Start()
    {
        StartCoroutine(Dash(dis, duration));
    }

    // Update is called once per frame
    IEnumerator Dash(float distance, float duration)
    {
         Vector3 start = transform.position;
         Vector3 end = start + transform.right * distance;
            float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }



    }
    
}
