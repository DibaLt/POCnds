using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EmergencyReturn : MonoBehaviour
{
    public InputActionProperty ButtonAction; // Assegna questa action nell'Inspector
    public Transform player; // Trascina qui il transform del personaggio nel'Inspector

    void Update()
    {
        // Verifica se il pulsante è stato premuto
        if (ButtonAction.action != null && ButtonAction.action.WasPressedThisFrame())
        {
            if (player != null)
            {
                player.position = transform.position;
            }
        }
    }
}
