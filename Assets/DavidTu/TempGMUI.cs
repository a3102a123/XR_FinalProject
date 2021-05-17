﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TempGMUI : MonoBehaviour
{
    GameObject Status_Obj;
    GameObject Chapter_Obj;
    // Start is called before the first frame update
    void Start()
    {
        Status_Obj = GameObject.Find("Status");
        Chapter_Obj = GameObject.Find("Chapter");
    }

    // Update is called once per frame
    void Update()
    {
        ShowStatus();
        ShowChapter();
    }

    public void changeScene(){
        SceneManager.LoadScene("TestScene2");
    }
    void ShowStatus(){
        Status status = GameManager.GM.GetStatus();
        Status_Obj.transform.Find("STR/num").GetComponent<Text>().text = status.STR.ToString();
        Status_Obj.transform.Find("INT/num").GetComponent<Text>().text = status.INT.ToString();
        Status_Obj.transform.Find("HATE/num").GetComponent<Text>().text = status.HATE.ToString();
    }
    void ShowChapter(){
        //Debug.Log(Chapter_Obj+" ||| " + Chapter_Obj.transform.Find("Round/num"));
        Round round = GameManager.GM.GetRound();
        Stage stage = GameManager.GM.GetStage();
        Chapter_Obj.transform.Find("Round/num").GetComponent<Text>().text = round.ToString();
        Chapter_Obj.transform.Find("Stage/num").GetComponent<Text>().text = stage.ToString();
    }
}