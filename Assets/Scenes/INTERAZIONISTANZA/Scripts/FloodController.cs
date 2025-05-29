using System.Collections;
using UnityEngine;

public class FloodController : MonoBehaviour
{
    public bool hasRead = false;  // Booleano che attiva o disattiva il movimento
    public float alzaAcqua = 4f;
    public float raiseDuration = 10f; // Durata del sollevamento della mesh
    public float moveDistance = 5f;  // Distanza che la mesh deve percorrere
    public float moveSpeed = 2f;  // Velocità di movimento
    public float yOscillationAmplitude = 0.5f;  // Ampiezza del movimento oscillante lungo l'asse Y
    public float yOscillationSpeed = 1f;  // Velocità del movimento oscillante lungo l'asse Y
    private Vector3 startPosition;  // Posizione iniziale della mesh
    private bool isMoving = false;

    public bool startFlood = false;
    public bool stopFlood = false;

    void Start()
    {
        startPosition = transform.position;  // Memorizza la posizione iniziale
    }

    void Update()
    {
        // Se il booleano startFlood è vero, avvia la coroutine per muovere la mesh
        if (startFlood && !isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveMesh());
        }
        // Se il booleano stopFlood è vero, ferma la coroutine e riporta la mesh alla posizione iniziale
        else if (stopFlood && isMoving)
        {
            isMoving = false;
            startFlood = false;
            StopCoroutine(MoveMesh());
            transform.position = startPosition;
        }
    }

    IEnumerator MoveMesh()
    {
        float elapsedTime = 0f;
        Vector3 raisedPosition = startPosition + Vector3.up * alzaAcqua;

        while (elapsedTime < raiseDuration)
        {
            transform.position = Vector3.Lerp(startPosition, raisedPosition, elapsedTime / raiseDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = raisedPosition;

        while (isMoving)
        {
            float yOscillation = Mathf.Sin(Time.time * yOscillationSpeed) * yOscillationAmplitude;
            Vector3 oscillatingPosition = new Vector3(raisedPosition.x, raisedPosition.y + yOscillation, raisedPosition.z);
            transform.position = oscillatingPosition;
            yield return null;
        }
    }

    public void StartFlood()
    {
        startFlood = true;
    }

    public void StopFlood()
    {
        stopFlood = true;
    }
}
