using UnityEngine;
using static Unity.VisualScripting.Member;

public class SoundManagerLegerdemain : MonoBehaviour
{
    AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayExplosionSound()
    {
        source.Play();
    }
}
