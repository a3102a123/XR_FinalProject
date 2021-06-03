using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 掛在擁有colider的物件上當玩家的controller進入時會觸發
public class EventTrigger : MonoBehaviour
{
    [HeaderAttribute("觸發的事件")]
    [SerializeField]
    private EventDecider Event;

    private bool is_enable = false;
    public void OnTriggerEnter(Collider other){
        Debug.Log(other.tag == "Interactable");
        if(!is_enable && other.tag != "Interactable"){
            Event.DecideEvent();
            is_enable = true;
        }
    }
}
