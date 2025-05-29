using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRain : MonoBehaviour
{

    [SerializeField] GameObject pioggia;
    public bool isRaining = false;

    public void OnTriggerEnter(Collider other)
    {
        pioggia.SetActive(true);
        isRaining = true;
    }
}
