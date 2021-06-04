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

    private int CurrentPoints = 0;
    private float t;
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
        this.CurrentPoints = player.getPoints();
        Points.text = "Points: " + CurrentPoints;
        if( t > 0 )
        {
            t -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(t / 60);
            float seconds = Mathf.FloorToInt(t % 60);
            time.text = minutes + " : " +  seconds;
        } 
        else
        {
            Debug.Log("Time has run out!");
            time.text = "Time's up !!";
            EndGame(CurrentPoints);
        }
    }

    void EndGame(int Points)
    {
        if( Points >= goal )
        {
            Debug.Log("You win this game");
        }
        else
        {
            Debug.Log("Tou lose this game");
        }
    }
}
