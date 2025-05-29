using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FootstepSound : MonoBehaviour
{
    public AudioSource footstepAudioSource; // Il componente AudioSource
    public AudioClip[] footstepSounds; // Array di suoni dei passi
    public float stepInterval; // Tempo tra un passo e l'altro

    private CharacterController characterController;
    private float stepTimer;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Controlla se il player si sta muovendo
        if (characterController != null && characterController.velocity.magnitude >= 2.0f)
        {
            
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepInterval)
            {
                PlayFootstep();
                stepTimer = 0f;
            }
        }
    }

    void PlayFootstep()
    {
        if (footstepSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepSounds.Length);
            footstepAudioSource.PlayOneShot(footstepSounds[0]);
        }
    }
}
