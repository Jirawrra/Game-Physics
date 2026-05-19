using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject objectToSpawn;

    [Header("Spawn Settings")]
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;

    public int maxObjects = 10;

    [Header("Spawn Area")]
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10);

    private int currentObjects = 0;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // Wait random interval before spawning
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);

            if (currentObjects < maxObjects)
            {
                SpawnObject();
            }
        }
    }

    void SpawnObject()
    {
        Vector3 randomPosition = transform.position + new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);

        currentObjects++;
    }

    // Call this when spawned object gets destroyed
    public void ObjectDestroyed()
    {
        currentObjects--;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}