using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    public AudioClip backgroundMusic; // Arrastra la música en el Inspector
    [Range(0f, 1f)] public float volume = 0.5f; // Control de volumen en el Inspector

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Evita que se destruya al cambiar de escena

            audioSource = gameObject.AddComponent<AudioSource>(); // Añade un AudioSource
            audioSource.clip = backgroundMusic;
            audioSource.loop = true; // Hace que la música se repita
            audioSource.volume = volume;
            audioSource.playOnAwake = true;
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject); // Evita duplicados si vuelves a la escena inicial
        }
    }

    public void SetVolume(float newVolume)
    {
        audioSource.volume = newVolume;
    }
}
