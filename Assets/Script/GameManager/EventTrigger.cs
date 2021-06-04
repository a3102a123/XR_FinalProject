using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 掛在擁有colider的物件上當玩家的controller進入時會觸發
public class EventTrigger : MonoBehaviour
{
    [HeaderAttribute("觸發的事件")]
    [SerializeField]
    private EventDecider Event;

    [HeaderAttribute("設定選項")]
    [SerializeField]
    [Tooltip("可以設定是否需要被其他script啟動")]
    private bool is_enable = false;

    [HeaderAttribute("Private flag")]
    [SerializeField]
    [Tooltip("顯示來幫忙debug，不受設定影響")]
    private bool is_triggered = false;
    void Start(){
        is_triggered = false;
    }
    public void OnTriggerEnter(Collider other){
        // 確保只被觸發一次
        if( is_enable && !is_triggered && other.tag != "Interactable"){
            is_triggered = Event.DecideEvent();
        }
    }
    // 使這個Trigger能夠被玩家互動
    public void Enable(){
        is_enable = true;
    }
    public string GetEventResult(){
        return Event.GetResult();
    }
}
