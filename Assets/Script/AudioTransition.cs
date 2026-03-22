using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    public static BackgroundAudio instance;

    public AudioSource audioSource;

    public AudioClip firstTrack;
    public AudioClip secondTrack;

    private bool hasSwitched = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        audioSource.loop = false;
        audioSource.clip = firstTrack;
        audioSource.Play();
    }

    void Update()
    {
        if (!hasSwitched && !audioSource.isPlaying)
        {
            hasSwitched = true;

            audioSource.clip = secondTrack;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}