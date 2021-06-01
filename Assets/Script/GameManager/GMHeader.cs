using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Route{
    NONE,
    A = 100,
    B,
    C,
}
public enum StatusType{
    STR,
    INT,
    HATE
}
public enum Size{
    Normal,
    Small,
    Tiny
}

[System.Serializable]
public class Status{
    [Tooltip("Strength")]
    public int STR;
    [Tooltip("Intelligent")]
    public int INT;
    [Tooltip("Hate of roommate")]
    public int HATE;
    public void init(){
        STR = 100;
        INT = 100;
        HATE = 0;
    }
    public void clear(){
        STR = -1;
        INT = -1;
        HATE = -1;
    }
    public void add(StatusType type,int num){
        ref int ability = ref DetType(type);
        ability += num;
    }
    // Determine which type of the ability should be change
    private ref int DetType(StatusType type){
        switch(type){
            case StatusType.STR:
                return ref STR;
            case StatusType.INT:
                return ref INT;
            case StatusType.HATE:
                return ref HATE;
            default:
                return ref STR;
        }
    }
    // Constructor
    public Status(int s,int i,int h){
        STR = s;
        INT = i;
        HATE = h;
    }
    public Status(){
        STR = -1;
        INT = -1;
        HATE = -1;
    }
}

[System.Serializable]
public class EventCondition{
    [HeaderAttribute("事件條件")]
    public Status max_status;
    public Status min_status;
    [HeaderAttribute("文本檔案路徑")]
    [Tooltip("輸入以Dialogue資料夾為根目錄的相對路徑")]
    public string dialogue_filename;
    // Constructor
    EventCondition(){
        min_status = new Status();
        max_status = new Status();
    }
}

[System.Serializable]
public class EndCondition{
    [HeaderAttribute("結局路線")]
    public Route EndRoute = Route.NONE;
    [HeaderAttribute("鍵盤遊戲成功的文本檔案路徑")]
    [Tooltip("輸入以Dialogue資料夾為根目錄的相對路徑")]
    public string success_filename;
    [HeaderAttribute("鍵盤遊戲失敗的文本檔案路徑")]
    [Tooltip("輸入以Dialogue資料夾為根目錄的相對路徑")]
    public string fail_filename;
    // Constructor
    EndCondition(){
        EndRoute = Route.NONE;
        success_filename = "./End/NONE/Success.txt";
        fail_filename = "./End/NONE/Fail.txt";
    }
}

[System.Serializable]
public class SelectOption{
    [HeaderAttribute("選擇碰撞點")]
    public SelectPoint Trigger_Point;
    [HeaderAttribute("選擇該選項的文本檔案路徑")]
    [Tooltip("輸入以Dialogue資料夾為根目錄的相對路徑")]
    public string filename;
}