using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    GameManager gm;
    public AudioClip[] songs;
    public AudioClip[] gaslightingSongs;

    AudioSource source;
    float currentSongLength;
    int index = 0;
    int index_gaslight = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        source = GetComponent<AudioSource>();
        source.clip = songs[0];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(source.time >= source.clip.length - 1.0f)
        {
            if(gm.timer_gaslight_player >= 29.0f)
            {
                source.clip = songs[index++];
                if(index == songs.Length)
                {
                    index = 0;
                }
            }
            else
            {
                source.clip = gaslightingSongs[index_gaslight++];
                if (index_gaslight == gaslightingSongs.Length)
                {
                    index_gaslight = 0;
                }

            }
            source.Play();

        }
    }

    public void MusicToGaslightPeopleTo()
    {
        source.clip = gaslightingSongs[index_gaslight++];
        source.Play();
    }
}
