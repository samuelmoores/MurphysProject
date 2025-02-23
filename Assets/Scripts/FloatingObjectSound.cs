using UnityEngine;

public class FloatingObjectSound : MonoBehaviour
{
    public AudioClip winSound;
    AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    public void PlayWinSound()
    {
        source.clip = winSound;
        source.Play();
    }
}
