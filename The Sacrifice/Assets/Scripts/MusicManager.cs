using UnityEngine;

public class MusicManager : MonoBehaviour
{


    private static AudioSource _audioSource;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (_audioSource == null)
        {
            _audioSource = this.GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
