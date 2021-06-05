﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderTableSceneManager : MonoBehaviour
{
    [HeaderAttribute("開始文本")]
    [SerializeField]
    private DialogueDisplayer Start_dia;

    [HeaderAttribute("行為選擇")]
    [SerializeField]
    private EventDecider ActionEvent;
    
    void Start()
    {
        Start_dia.Activate();
    }

    void Update()
    {
        
    }

    void Action(){
        string result = ActionEvent.GetResult();
        if(result != ""){
            Debug.Log(result);
            //change scene
        }
    }
}
