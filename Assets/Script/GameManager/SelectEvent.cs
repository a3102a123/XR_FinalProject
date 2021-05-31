using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEvent : MonoBehaviour
{
    [HeaderAttribute("該事件能夠選擇的選項")]
    public SelectOption [] Option_List = new SelectOption[2];
    public void Start(){

    }
    public void Selected(GameObject obj){
        Debug.Log(this.name + " : get " + obj);
        DialogueDisplayer displayer;
        string filename;
        int i ;
        for(i = 0 ; i < Option_List.Length ; i++){
            SelectOption option = Option_List[i];
            var trigger_colider = option.Trigger_Point.gameObject.GetComponent<Collider>();
            if(obj.GetComponent<Collider>() == trigger_colider){
                displayer = gameObject.AddComponent<DialogueDisplayer>() as DialogueDisplayer;
                filename = option.filename;
                displayer.Constructor(filename);
                Debug.Log(filename);
                if(!displayer.Activate()){
                    Debug.Log("[SelectEvent] " + this.name + "Event initial failed!");
                    Destroy(displayer);
                };
                break;
            }
        }
        // 關閉選擇完的事件避免二次觸發
        /*if(i != Option_List.Length){
            this.enabled = true;
        }*/
    }
}
