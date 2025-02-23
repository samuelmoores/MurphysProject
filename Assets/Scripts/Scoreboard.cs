using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public GameObject scoreboard;
    public GameObject hallOfFame;
    public GameObject urGOD;
    public GameObject WOW;
    TextMeshProUGUI text_mesh;
    GameManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text_mesh = GetComponent<TextMeshProUGUI>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(manager.HookThePlayerUp() < 0)
        {
            hallOfFame.SetActive(true);
        }
        else
        {
            text_mesh.text = manager.HookThePlayerUp().ToString();

            if(manager.HookThePlayerUp() > 1000)
            {
                WOW.SetActive(true);
            }

            if(manager.HookThePlayerUp() > 100000)
            {
                urGOD.SetActive(true);
            }
        }

        if(manager.timer_gaslight_player < 0.0f)
        {
            hallOfFame.SetActive(false);

        }

    }

}
