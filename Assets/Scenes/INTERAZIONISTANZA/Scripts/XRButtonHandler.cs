using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class XRButtonHandler : MonoBehaviour
{
    public InputActionProperty xButtonAction; // Assegna questa action nell'Inspector
    public GameObject leftControllerVisual; // Modello del controller sinistro
    public GameObject pokeInteractor;
    public GameObject nearFarInteractor;
    public GameObject phoneCanvas; // Canvas del telefono

    void Update()
    {
        if (xButtonAction.action.WasPressedThisFrame())
        {
            ToggleObjects();
        }
    }

    void ToggleObjects()
    {
        if (leftControllerVisual != null && phoneCanvas != null)
        {
            // Se il controller sinistro è attivo, disattivalo e attiva il phoneCanvas
            if (leftControllerVisual.activeSelf)
            {
                leftControllerVisual.SetActive(false);
                pokeInteractor.SetActive(false);
                nearFarInteractor.SetActive(false);
                phoneCanvas.SetActive(true);
            }
            // Se il phoneCanvas è attivo, disattivalo e attiva il controller sinistro
            else if (phoneCanvas.activeSelf)
            {
                phoneCanvas.SetActive(false);
                leftControllerVisual.SetActive(true);
                pokeInteractor.SetActive(true);
                nearFarInteractor.SetActive(true);
            }
            // Se entrambi sono disattivati, attiva il controller sinistro come predefinito
            else
            {
                leftControllerVisual.SetActive(true);
                pokeInteractor.SetActive(true);
                nearFarInteractor.SetActive(true);
            }
        }
    }
}
