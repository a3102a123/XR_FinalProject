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
    // 玩家在多線故事的哪條路線上
    private Route route;
    [SerializeField]
    // 玩家大小
    private Size size;
    [SerializeField]
    // 玩家能力值
    private Status status;
    // 獲得的道具
    public bool Smartphone;
    public bool Earphone;
    public bool Knife;
    public bool TestPaper;

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
        route = Route.NONE;
        size = Size.Tiny;
        Smartphone = false;
        Earphone = false;
        Knife = false;
        TestPaper = false;
        status.init();
    }
    public void ChangeStatus(Status stat){
        status.add(StatusType.STR,stat.STR);
        status.add(StatusType.INT,stat.INT);
        status.add(StatusType.HATE,stat.HATE);
    }
    public void ChangeRoute(Route new_route){
        route = new_route;
    }
    // get gamemanager private variable
    public Status GetStatus(){
        return status;
    }
    public Route GetRoute(){
        return route;
    }
    // [min,max]
    public bool CheckLimit(Status min_status,Status max_status){
        // check STR
        if(min_status.STR != -1 || max_status.STR != -1){
            int value = this.status.STR;
            int max = max_status.STR;
            int min = min_status.STR;
            if(min_status.STR != -1 && value < min){
                return false;
            }
            if(max_status.STR != -1 && value > max){
                return false;
            }
        }
        // check INT
        if(min_status.INT != -1 || max_status.INT != -1){
            int value = this.status.INT;
            int max = max_status.INT;
            int min = min_status.INT;
            if(min_status.INT != -1 && value < min){
                return false;
            }
            if(max_status.INT != -1 && value > max){
                return false;
            }
        }
        // check HATE
        if(min_status.HATE != -1 || max_status.HATE != -1){
            int value = this.status.HATE;
            int max = max_status.HATE;
            int min = min_status.HATE;
            if(min_status.HATE != -1 && value < min){
                return false;
            }
            if(max_status.HATE != -1 && value > max){
                return false;
            }
        }
        // 能力值的限制皆符合回傳true
        return true;
    }
}
