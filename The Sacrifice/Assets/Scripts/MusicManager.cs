using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    private static MusicManager musicManagerInstance;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);

        if (musicManagerInstance == null)
        {
            musicManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
