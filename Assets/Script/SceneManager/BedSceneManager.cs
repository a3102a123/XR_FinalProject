using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BedSceneManager : MonoBehaviour
{
    [HeaderAttribute("開始文本")]
    [SerializeField]
    private DialogueDisplayer Start_dia;
    [HeaderAttribute("探索結束")]
    [SerializeField]
    private bool is_awake = false;
    [SerializeField]
    private GameObject Pillow;
    [SerializeField]
    private GameObject Earphone;
    [SerializeField]
    private GameObject SmartPhone;
    [SerializeField]
    private EventTrigger Enabled_EventTrigger;
    [HeaderAttribute("準備離開床上")]
    [SerializeField]
    private SelectEvent LeaveEvent;

    DialogueDisplayer displayer = null;
    bool is_change = false;
    void Start(){
        //initial
        if(displayer == null){
            string filename = "Bed/Chapter2/Awake.txt";
            displayer = gameObject.AddComponent<DialogueDisplayer>() as DialogueDisplayer;
            displayer.Constructor(filename);
        }
        Start_dia.Activate();
    }
    // Update is called once per frame
    void Update()
    {
        isGrabbed();
        ExploredResult();
        SelectLeaveWay();
    }
    void isGrabbed(){
        GameManager GM = GameManager.GM;
        if( !is_awake && Pillow.GetComponent<InteractObj>().GetCount() > 0){
            // 反覆呼叫直到成功顯示文本
            if(displayer.Activate()){
                Enabled_EventTrigger.Enable();
                is_awake = true;
            }
        }
        if(!is_awake && SmartPhone.GetComponent<InteractObj>().GetCount() == 1){
            GM.Smartphone = true;
        }
        if(!is_awake && Earphone.GetComponent<InteractObj>().GetCount() == 1){
            GM.Earphone = true;
        }
    }
    void ExploredResult(){
        string jump = "Bed/Chapter2/Jump.txt";
        string leave = "Bed/Chapter2/LeaveBed.txt";
        string result = Enabled_EventTrigger.GetEventResult();
        if( result == jump ){
            Debug.Log("Jump");
            //change scene
            if(!is_change){
                is_change = GameManager.GM.ChangeScene("AfterDead");
            }
        }
        else if(result == leave){
            Debug.Log("Leave Bed");
            LeaveEvent.Enable();
        }
    }

    void SelectLeaveWay(){
        string ladder = "Bed/Chapter2/Ladder.txt";
        string phone = "Bed/Chapter2/Earphone.txt";
        string result = LeaveEvent.GetResult();
        if( result == ladder ){
            Debug.Log("Ladder");
            if (!is_change)
            {
                is_change = GameManager.GM.ChangeScene("Floor");
            }
            //change scene
        }
        else if(result == phone){
            Debug.Log("Earphone");
            if (!is_change)
            {
                is_change = GameManager.GM.ChangeScene("Floor");
            }
            //change scene
        }
    }
}
