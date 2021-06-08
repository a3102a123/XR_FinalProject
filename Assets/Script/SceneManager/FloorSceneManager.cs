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
    private bool is_change = false;
    private SelectEvent MoveEvent = null;

    void Start(){
        is_init = false;
        is_conv = false;
        is_change = false;
        MoveEvent = null;
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
        MoveWay();
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
            if (!is_change)
            {
                Debug.Log("Floor : Route C");
                // 確認為C路線
                GameManager.GM.ChangeRoute(Route.C);
                is_change = GameManager.GM.ChangeScene("AfterDead");
            }
            //change scene
        }
    }
    void ExploredResult(){
        if(is_conv){
            Status stat = GameManager.GM.GetStatus();
            if(MoveEvent == null) {
                if(stat.STR > GM_ori_stat.STR){
                    MoveEvent = EventBoth;
                    EventBoth.Enable();
                }
                else{
                    MoveEvent = EventOnlyRide;
                    EventOnlyRide.Enable();
                }
            }
        }
    }
    void MoveWay()
    {
        if(MoveEvent == null)
        {
            return;
        }
        string result = MoveEvent.GetResult();
        string ride = "Floor/Chapter2/Ride.txt";
        string explore = "Floor/Chapter2/Explore.txt";
        if (result == ride)
        {
            Debug.Log("Ride");
            //change scene
            if (!is_change)
            {
                Debug.Log("Floor : Route A");
                // 確認為A路線
                GameManager.GM.ChangeRoute(Route.A);
                is_change = GameManager.GM.ChangeScene("ToTable");
            }
        }
        else if (result == explore)
        {
            Debug.Log("Explore");
            //change scene
            if (!is_change)
            {
                is_change = GameManager.GM.ChangeScene("UnderTable");
            }
        }
    }
}
