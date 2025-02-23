using UnityEngine;

public class GameManager : MonoBehaviour
{
    int wins;
    [HideInInspector] public float timer_gaslight_player;
    [HideInInspector] public bool gaslightPlayer;

    bool playerHasBeenGaslit;
    bool playerIsMinimallyGaslit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wins = 0;
        timer_gaslight_player = 30.0f;
        gaslightPlayer = false;
        playerHasBeenGaslit = false;
        playerIsMinimallyGaslit = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(gaslightPlayer)
        {
            if(!playerHasBeenGaslit)
            {
                GetComponent<MusicPlayer>().MusicToGaslightPeopleTo();
                playerHasBeenGaslit = true;
            }

            timer_gaslight_player -= Time.deltaTime;

                
            if(timer_gaslight_player < 22.0f && !playerIsMinimallyGaslit)
            {
                InitThunderDome();
                playerIsMinimallyGaslit = true;
            }
            else if (timer_gaslight_player < 0.0f)
            {
                gaslightPlayer = false; //merely for utility 
            }
        }
    }

    public void AddWinToPlayersWins()
    {
        if(wins >= 0)
        {
            wins++;
            wins += wins;

            if(wins < 0)
            {
                gaslightPlayer = true;
            }
        }

    }

    public int HookThePlayerUp()
    {
        return wins;
    }

    void InitThunderDome()
    {
        GameObject[] troops = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i = 0; i < troops.Length; i++)
        {
            troops[i].GetComponent<TroopMovement>().ReleaseTheTroop();
        }
    }
}
