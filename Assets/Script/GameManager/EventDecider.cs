using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EventDecider : MonoBehaviour
{
    [SerializeField]
    private EventCondition[] Event_List = new EventCondition[2];

    [HeaderAttribute("Private Variable")]
    [Tooltip("顯示來幫忙debug，不受設定影響")]
    [SerializeField]
    //用文本file path來代表選擇結果
    private string EventResult = "";
    // Start is called before the first frame update
    void Start()
    {
        EventResult = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool DecideEvent(){
        int i ;
        int len = Event_List.Length;
        DialogueDisplayer displayer;
        EventCondition Event = null;
        for(i = 0 ; i < len ; i++ ){
            Event = Event_List[i];
            Status min_stat = Event.min_status;
            Status max_stat = Event.max_status;
            Debug.Log("[EventDecider] : " + i + " / " + len);
            if(GameManager.GM.CheckLimit(min_stat,max_stat)){
                break;
            }
            if(i == len-1){
                // all Events don't meet the condition
                Debug.Log("[EventDecider] " + this.name + " : No One Meet!");
                return false;
            }
        }
        // prevent the Event is empty
        if(Event == null)
            return false;
        string filename = Event.dialogue_filename;
        Debug.Log("[EventDecider] " + this.name + " : Decide display " + filename);
        displayer = gameObject.AddComponent<DialogueDisplayer>() as DialogueDisplayer;
        displayer.Constructor(filename);
        // test whether displayer successful activate
        if(!displayer.Activate()){
            Debug.Log("[EventDecider] " + this.name + "Event initial failed!");
            Destroy(displayer);
            return false;
        };
        EventResult = filename;
        return true;
    }
    public string GetResult(){
        return EventResult;
    }
    // 使遊戲進行時可以根據玩家選項修改選項能力值限制
    public void SetEvent(int idx,Status new_max_stat,Status new_min_stat){
        EventCondition Event = Event_List[idx];
        Event.max_status = new_max_stat;
        Event.min_status = new_min_stat;
    }
}
