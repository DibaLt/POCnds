using UnityEngine;
using System.Collections;

public class CollisionColorChange : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;
    public float colorChangeDuration = 0.5f; // Durata totale della transizione

    public GameObject objectRed;

    void Start()
    {
        objectRenderer = objectRed.GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (objectRenderer != null)
        {
            StopAllCoroutines(); // Ferma eventuali transizioni in corso
            StartCoroutine(ChangeColorGradually(Color.red, originalColor, colorChangeDuration));
        }
    }

    IEnumerator ChangeColorGradually(Color targetColor, Color returnColor, float duration)
    {
        float elapsedTime = 0f;
        Color startColor = objectRenderer.material.color;

        // Fase 1: Cambia gradualmente al colore target (rosso)
        while (elapsedTime < duration / 2)
        {
            objectRenderer.material.color = Color.Lerp(startColor, targetColor, elapsedTime / (duration / 2));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectRenderer.material.color = targetColor; // Assicura che diventi completamente rosso

        // Aspetta un attimo prima di tornare indietro
        yield return new WaitForSeconds(0.2f);

        elapsedTime = 0f;
        startColor = objectRenderer.material.color;

        // Fase 2: Torna gradualmente al colore originale
        while (elapsedTime < duration / 2)
        {
            objectRenderer.material.color = Color.Lerp(startColor, returnColor, elapsedTime / (duration / 2));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectRenderer.material.color = returnColor; // Assicura che torni al colore originale
    }
}