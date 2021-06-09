using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableGameManager : MonoBehaviour
{
    public Text time;
    public Player player;
    public Text Points;
    public float TotalTime = 60;
    public int goal = 300;
    public EndDecider End;
    public DialogueDisplayer Dia_start;

    private int CurrentPoints = 0;
    private float t;
    private bool scene_flag = false;
    private bool game_done = false;
    private bool game_start = true;
    private bool win;
    // Start is called before the first frame update
    void Start()
    {
        Points.gameObject.SetActive(true);
        time.gameObject.SetActive(true);
        t = TotalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if( game_start == true )
        {
            Dia_start.Activate();
            game_start = false;
        }
        else
        {
            if ( game_done == true )
            {
                GameManager GM = GameManager.GM;
                Route path = GM.GetRoute();

                if ( scene_flag == false && (path == Route.A || path == Route.B) && win == false)
                {
                    scene_flag = GM.ChangeScene("TampleRun");
                }
                else if ( scene_flag == false && (path == Route.A || path == Route.C) && win == true)
                {
                    scene_flag = GM.ChangeScene("Final_video_2");
                }
                else if( scene_flag == false )
                {
                    scene_flag = GM.ChangeScene("Final_video_3");
                }
            }

            if( t > 0 )
            {
                this.CurrentPoints = player.getPoints();
                Points.text = "Points: " + CurrentPoints;
                t -= Time.deltaTime;
                float minutes = Mathf.FloorToInt(t / 60);
                float seconds = Mathf.FloorToInt(t % 60);
                time.text = minutes + " : " +  seconds;
            } 
            else if( t > -10 )
            {
                Debug.Log("Time has run out!");
                time.text = "Time's up !!";
                EndGame(CurrentPoints);
            }
        }
    }

    void EndGame(int Points)
    { 
        t -= 10;
        if( Points >= goal )
        {
            Debug.Log("You win this game");
            End.DecideEnd(false);
            game_done = true;
            win = true;
        }
        else
        {
            Debug.Log("You lose this game");
            End.DecideEnd(true);
            game_done = true;
            win = false;
        }
    }
}
