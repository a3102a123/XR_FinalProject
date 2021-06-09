using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TamplerunManager : MonoBehaviour
{
    public GameObject wideObstacle;
    public GameObject heightObstacle;
    public Transform startCenter;
    public float Ins_time = 1; 
    public float h = 3f;
    public float v = 2.5f;

    public Text time;
    public Player player;
    public Text Points;
    public float TotalTime = 60;
    public int goal = -200;
    public DialogueDisplayer Dia_start;

    private int CurrentPoints = 0;
    private float t;
    private bool game_start = true;
    private bool game_end = false;
    private bool scene_flag = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Ins_Objs", Ins_time + 2, Ins_time);
        Points.gameObject.SetActive(true);
        time.gameObject.SetActive(true);
        t = TotalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if( game_end == true )
        {
            GameManager GM = GameManager.GM;
            GM.ChangeRoute(Route.End);
            if ( scene_flag == false )
            {
                scene_flag = GM.ChangeScene("Teacher_room");
            }
        }

        if( game_start == true )
        {
            Dia_start.Activate();
            game_start = false;
        }
        else
        {
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

    void Ins_Objs()
    {
        int type = Random.Range(0, 2);
        if (type == 0)
        {
            float r_v = Random.Range(0, v);
            Vector3 myVector = new Vector3(0, r_v, 0);

            Instantiate( wideObstacle, startCenter.transform.position+myVector, Quaternion.Euler (0f, 90f, 0f));
        }
        else
        {
            float r_h = Random.Range(-h, h);
            Vector3 myVector = new Vector3(r_h, v/2, 0);

            Instantiate( heightObstacle, startCenter.transform.position+myVector, Quaternion.Euler (0f, 90f, 0f));
        }
    }

    void EndGame(int Points)
    { 
        t -= 10;
        CancelInvoke();
        if( Points >= goal )
        {
            Debug.Log("You win this game");
            game_end = true;
        }
        else
        {
            Debug.Log("You lose this game");
            game_end = true;
        }
    }
}
