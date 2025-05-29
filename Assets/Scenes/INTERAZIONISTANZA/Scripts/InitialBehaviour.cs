using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialBehaviour : MonoBehaviour, IPooledObject
{
    public void OnObjectSpawn()
    {
        float xForce = 0f;
        float yForce = 0f;
        float zForce = -1f;

        Vector3 force = new Vector3(xForce, yForce, zForce);

        GetComponent<Rigidbody>().velocity = force;
    }
}
