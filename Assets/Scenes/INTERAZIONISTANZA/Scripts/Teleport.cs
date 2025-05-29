using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public Transform teleportTarget;
    public GameObject character;

    //si potrebbe mettere un controllo per farlo funzionare solo se è l'utente a collidere
     void OnTriggerEnter(Collider other) {
        character.transform.position = teleportTarget.transform.position;
    }
}
