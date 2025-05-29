using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valle : MonoBehaviour
{
    [SerializeField] GameObject hub;
    public bool isLoad = false;

    // Metodo per impostare isLoad a true
    public void SetTrue()
    {
        isLoad = true;
    }

    // Metodo per impostare isLoad a false
    public void SetFalse()
    {
        isLoad = false;
    }
}
