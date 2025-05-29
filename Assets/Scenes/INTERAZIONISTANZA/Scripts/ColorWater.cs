using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWater : MonoBehaviour
{
    public Material material1; // Materiale iniziale
    public Material material2; // Materiale alternativo

    private Renderer rend;
    private bool usingMaterial1 = true;

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (rend == null)
        {
            Debug.LogError("MaterialChanger: Nessun Renderer trovato sull'oggetto.");
            return;
        }

        if (material1 == null || material2 == null)
        {
            Debug.LogError("MaterialChanger: Assicurati di assegnare entrambi i materiali.");
            return;
        }

        // Imposta il materiale iniziale
        rend.material = material1;
        usingMaterial1 = true;
    }

    public void ChangeMaterial()
    {
        if (rend == null || material1 == null || material2 == null) return;

        if (usingMaterial1)
        {
            rend.material = material2;
        }
        else
        {
            rend.material = material1;
        }

        usingMaterial1 = !usingMaterial1;
    }
}