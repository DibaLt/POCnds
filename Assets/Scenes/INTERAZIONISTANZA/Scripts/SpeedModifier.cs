using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;

public class SpeedModifier : MonoBehaviour
{
    [SerializeField] private ContinuousMoveProvider dynamicMoveProvider;
    public InputActionProperty ButtonAction;
    public float runningSpeed = 5f;

    void Update()
    {
        // Controlla se il pulsante è tenuto premuto
        bool running = ButtonAction.action.IsPressed();

        // Imposta la velocità in base allo stato di corsa
        if (running)
        {
            dynamicMoveProvider.moveSpeed = runningSpeed; // Velocità di corsa
        }
        else
        {
            dynamicMoveProvider.moveSpeed = 2.5f; // Velocità normale
        }
    }
}
