using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSceneManager : MonoBehaviour
{
    [HeaderAttribute("開始文本")]
    [SerializeField]
    private DialogueDisplayer Start_dia;
    [HeaderAttribute("探索結束")]
    [SerializeField]
    private GameObject Testpaper;
    [SerializeField]
    private GameObject Knife;
    [HeaderAttribute("遇到春嬌事件 Trigger")]
    [SerializeField]
    private EventDecider MosquitoEvent;
    [SerializeField]
    private EventTrigger MosquitoEventTrigger;
    [HeaderAttribute("前往桌上的事件(根據能力值而有不同選項)")]
    [SerializeField]
    private SelectEvent EventOnlyRide;
    [SerializeField]
    private SelectEvent EventBoth;

    private Status GM_ori_stat;
    private bool is_init = false;
    private bool is_conv = false;

    void Start(){
        is_init = false;
        is_conv = false;
        Start_dia.Activate();
    }

    // Update is called once per frame
    void Update()
    {
        if(!is_init){
            init();
        }
        isGrabbed();
        MeetMosquito();
        ExploredResult();
    }

    void init(){
        GM_ori_stat = new Status(GameManager.GM.GetStatus());
        Status min_stat = GM_ori_stat;
        Status max_stat = new Status();
        min_stat.INT += 1;
        //使拿起考卷也可以選擇前往桌上
        MosquitoEvent.SetEvent(1,max_stat,min_stat);
        is_init = true;
    }

    void isGrabbed(){
        GameManager GM = GameManager.GM;
        if(Testpaper.GetComponent<InteractObj>().GetCount() == 1){
            GM.TestPaper = true;
        }
        if(Knife.GetComponent<InteractObj>().GetCount() == 1){
            GM.Knife = true;
        }
    }

    void MeetMosquito(){
        string result = MosquitoEventTrigger.GetEventResult();
        string converse = "Floor/Chapter2/Converse.txt";
        string scared = "Floor/Chapter2/Scared.txt";
        if(result == converse){
            Debug.Log("Converse");
            is_conv = true;
        }
        else if(result == scared){
            Debug.Log("Scared!");
            //change scene
        }
    }
    void ExploredResult(){
        if(is_conv){
            Status stat = GameManager.GM.GetStatus();
            if(stat.STR > GM_ori_stat.STR){
                EventBoth.Enable();
            }
            else{
                EventOnlyRide.Enable();
            }
        }
    }
}
