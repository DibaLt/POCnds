using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource uiClickAudio;
    public AudioSource backgroundMusic;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // elimina i duplicati
            return;
        }

        // Avvia musica se presente
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.loop = true;
            backgroundMusic.Play();
        }
    }

    public void PlayUIClick()
    {
        if (uiClickAudio != null)
            uiClickAudio.Play();
    }

    public void PlayOneShot(AudioClip clip)
    {
        if (uiClickAudio != null && clip != null)
            uiClickAudio.PlayOneShot(clip);
    }

    public void StopMusic()
    {
        if (backgroundMusic != null)
            backgroundMusic.Stop();
    }

    public void PlayMusic()
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
            backgroundMusic.Play();
    }

    public void ChangeMusic(AudioClip newClip)
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.clip = newClip;
            backgroundMusic.Play();
        }
    }
}
