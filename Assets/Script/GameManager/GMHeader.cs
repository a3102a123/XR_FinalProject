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
}

