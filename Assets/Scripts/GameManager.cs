using UnityEngine;

public class GameManager : MonoBehaviour
{
    int wins;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Wow! You have won " + wins + " times. Are you actually okay or are you GOD?");
    }

    public void AddWinToPlayersWins()
    {
        if(wins >= 0)
        {
            wins++;
            wins *= 2;
        }

    }

    public int HookThePlayerUp()
    {
        return wins;
    }
}
