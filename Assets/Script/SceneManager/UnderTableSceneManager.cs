using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderTableSceneManager : MonoBehaviour
{
    [HeaderAttribute("開始文本")]
    [SerializeField]
    private DialogueDisplayer Start_dia;

    [HeaderAttribute("行為選擇")]
    [SerializeField]
    private SelectEvent ActionEvent;

    private bool is_init = false;
    
    void Start()
    {
        is_init = false;
        Start_dia.Activate();
    }

    void Update()
    {
        if( !is_init && UIManager.Instance.displayer == null){
            ActionEvent.Enable();
            is_init = true;
        }
    }

    void Action(){
        string result = ActionEvent.GetResult();
        if(result != ""){
            Debug.Log(result);
            //change scene
        }
    }
}
