using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    // Let variable only be changed in GM
    [HeaderAttribute("Private 能力值 (當GM被創建時將會被自動初始化)")]
    [SerializeField]
    // 死過幾次或是經過幾天(類似章節，死一次或過完一天[完成3個事件]算進到一個新的章節)
    private Round round;
    [SerializeField]
    // 當前該輪的第幾個事件
    private Stage stage;
    [SerializeField]
    // 玩家大小
    private Size size;
    [SerializeField]
    // 玩家能力值
    private Status status;

    [HeaderAttribute("Develop Option")]
    [SerializeField]
    [Tooltip("勾選後會維持能力值設定而不會初始化 for debug")]
    private bool Not_init;
    // Start is called before the first frame update
    void Start()
    {
        GM = this;
        DontDestroyOnLoad(this);
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void init(){
        if(Not_init){
            Debug.Log("[GameManager] " + this.name +" : GM maintain the setting of developer");
            return;
        }
        round = Round.Begin;
        stage = Stage.Event1;
        size = Size.Tiny;
        status.init();
    }
    public void ChangeStatus(Status stat){
        status.add(StatusType.STR,stat.STR);
        status.add(StatusType.INT,stat.INT);
        status.add(StatusType.HATE,stat.HATE);
    }
    // 使事件+1 如果已完成一天的任務數則觸發 NextRound
    public void NextStage(){
        stage += 1;
        if(stage == Stage.Final){
            Debug.Log("[GameManager] " + this.name + " : Player finis all event in one day.");
            NextRound();
        }
    }
    // 死亡或過一天後 round +1 並將 stage 初始化為 Event1
    public void NextRound(){
        round += 1;
        if(round != Round.Final){
            stage = Stage.Event1;
        }
        else{
            Debug.Log("[GameManager] " + this.name + " : It's already in final round. Can't dead again.");
        }
    }
    // 死亡事件(round +1、初始 stage、[回到最初場景]) [] : 未完成考慮中...
    public void DeadEvent(){
        NextRound();
    }
    // get gamemanager private variable
    public Status GetStatus(){
        return status;
    }
    public Round GetRound(){
        return round;
    }
    public Stage GetStage(){
        return stage;
    }
}
