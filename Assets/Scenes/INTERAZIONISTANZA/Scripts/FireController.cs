using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject[] AllGameObjects;
    private float[] distances;
    public GameObject firePrefab;
    public GameObject parentObject;
    public float timeToSpawn;
    public float timeToDestroy;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    public bool startFire = false;
    public bool stopFire = false;

    IEnumerator ToggleFireStartCorutine(GameObject[] gameObjects)
    {
        for (int i=0; i<gameObjects.Length; i++) {
            Vector3 spawnPosition = AllGameObjects[i].transform.position + new Vector3(0, 1f, 0);
            GameObject spawnedObject = Instantiate(firePrefab, spawnPosition, Quaternion.identity, parentObject.transform);
            spawnedObjects.Add(spawnedObject);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }

    IEnumerator ToggleFireEndCorutine(GameObject[] gameObjects)
    {
        for (int i=0; i<gameObjects.Length; i++) {
            Destroy(AllGameObjects[i]);
            Destroy(spawnedObjects[i]);
            yield return new WaitForSeconds(timeToDestroy);
        }
    }
    void Start()
    {
        AllGameObjects = GameObject.FindGameObjectsWithTag("Tree");
        SortByDistance(AllGameObjects);
    }

    void Update()
    {
        if(startFire)
        {
            StartCoroutine(ToggleFireStartCorutine(AllGameObjects));
            startFire = false;
        }

        if(stopFire)
        {
            StartCoroutine(ToggleFireEndCorutine(AllGameObjects));
            stopFire = false;
        }
    }

    private void SortByDistance(GameObject[] gameObjects)
    {
        distances = new float[gameObjects.Length];
        for (int i=0; i<gameObjects.Length; i++)
        {
            distances[i] = Vector3.Distance(this.transform.position, gameObjects[i].transform.position);
        }
        SelectionSort(distances, gameObjects);
    }

    private void SelectionSort(float[] distances, GameObject[] gameObjects)
    {
        int n = distances.Length;

        for (int i=0; i<n-1; i++)
        {
            int minIndex = i;
            for (int j=i+1; j<n; j++)
            {
                if (distances[j]<distances[minIndex])
                {
                    minIndex = j;
                }
            }

            (distances[i], distances[minIndex]) = (distances[minIndex], distances[i]);
            (gameObjects[i], gameObjects[minIndex]) = (gameObjects[minIndex], gameObjects[i]);
        }
    }

    public void StartFire(){
            startFire=true;
        }

    public void StopFire(){
            stopFire = true;
        }
}
