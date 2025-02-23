using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    AudioSource source;
    public AudioClip[] conjurSounds;
    int index = 0;
    public AudioClip explosionSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            source.volume = 1.0f;
            source.clip = conjurSounds[index++];
            source.Play();

            if (index == conjurSounds.Length)
            {
                index = 0;
            }
        }
    }

    public void PlayExplosionSound()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManagerLegerdemain>().PlayExplosionSound();
    }

}
