using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEvent : MonoBehaviour
{
    [HeaderAttribute("該事件能夠選擇的選項")]
    public SelectOption [] Option_List = new SelectOption[2];

    [HeaderAttribute("設定選項")]
    [SerializeField]
    [Tooltip("可以設定是否需要被其他script啟動")]
    private bool is_enable = false;
    
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
    public bool Selected(GameObject obj){
        DialogueDisplayer displayer;
        string filename;
        int i ;
        // 避免二次觸發
        if( !is_enable || EventResult != ""){
            return true;
        }
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
                    return false;
                };
                EventResult = filename;
                return true;
            }
        }
        return false;
        // 關閉選擇完的事件避免二次觸發
        /*if(i != Option_List.Length){
            this.enabled = true;
        }*/
    }
    public void Enable(){
        is_enable = true;
    }
    public string GetResult(){
        return EventResult;
    }
}
