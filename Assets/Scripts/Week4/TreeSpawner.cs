using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [Header("Prefab To Spawn")]
    public GameObject prefab;

    [Header("Raycast Settings")]
    public Camera cam;
    public float maxDistance = 100f;

    [Header("Tree Check")]
    public float checkRadius = 2f;
    public LayerMask treeLayer;

    void Update()
    {
        // Left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Shoot raycast
            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                // Check if we hit the ground
                if (hit.collider.CompareTag("Ground"))
                {
                    PlaceTree(hit.point);
                }
            }
        }
    }

    void PlaceTree(Vector3 position)
    {
        // Check if another tree already exists nearby
        Collider[] colliders = Physics.OverlapSphere(
            position,
            checkRadius,
            treeLayer
        );

        // Only place if no trees found
        if (colliders.Length == 0)
        {
            Instantiate(prefab, position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Tree already exists here!");
        }
    }

    // Optional: visualize overlap radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
    }
}