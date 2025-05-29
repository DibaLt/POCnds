using System.Collections;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    public float spawnDelay = 1f; // Time delay between spawns in seconds
    public bool startSpawning = false; // Public variable to control starting spawn
    public bool stopSpawning = false; // Public variable to control stopping spawn
    private bool isSpawning = false;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void Update()
    {
        // Check if spawning should start
        if (startSpawning && !isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnWithDelay());
        }

        // Check if spawning should stop
        if (stopSpawning && isSpawning)
        {
            isSpawning = false;
            startSpawning = false;
            StopCoroutine(SpawnWithDelay());
        }
    }

    IEnumerator SpawnWithDelay()
    {
        while (isSpawning)
        {
            objectPooler.SpawnFromPool("Rock_A_01", transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnDelay); // Wait for the specified time before spawning again
        }
    }

    public void StartSpawn(){
            startSpawning=true;
        }

    public void StopSpawn(){
            stopSpawning = true;
        }
}
