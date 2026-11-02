using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isPlaying = true;
    }

    public void StopPlaying()
    {
        audioSource.Stop();
        isPlaying = false;
    }
}