using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionTrigger : MonoBehaviour
{
    [HeaderAttribute("選項是否被觸發並完成")]
    [SerializeField]
    private bool is_finish = false;

    [HeaderAttribute("觸發後影響的能力值變化")]
    public Status effect_status = new Status(0,0,0);

    [HeaderAttribute("是否有能力值限制")]

    [SerializeField]
    [Tooltip("設為 true 來啟用能力值限制判斷")]
    private bool is_limit = false;
    [Tooltip("能力值的 max 或 min 皆設為-1表示不檢查該能力值的限制")]
    [SerializeField]
    private Status max_status = new Status(-1,-1,-1);
    [Tooltip("能力值的 max 或 min 皆設為-1表示不檢查該能力值的限制")]
    [SerializeField]
    private Status min_status = new Status(-1,-1,-1);

    void start(){
        is_finish = false;
    }

    // 獲取當前該選項是否完成
    public bool GetFinish(){
        return is_finish;
    }

    // 自動檢查是否符合設定條件，其他物件只需直接呼叫來設置選項完成
    // 如果符合則呼叫GM更改能力值及檢查章節設置呼叫GM更改章節
    // 回傳是否設置的結果 for check
    public bool SetFinish(){
        LogMsg();
        if(Check()){
            if(!is_finish){
                is_finish = true;
                GameManager.GM.ChangeStatus(effect_status);
            }
            else{
                Debug.Log( "[OptionTrigger] " + this.name + " : is already finished!");
            }
        }
        return is_finish;
    }
    // 檢查是否符合能力值限制
    public bool Check(){
        if(is_limit){
            return GameManager.GM.CheckLimit(min_status,max_status);
        }
        else{
            // 沒有能力限制,回傳true
            return true;
        }
    }
    // function for button to trigger
    public void ButtonFinish(){
        SetFinish();
    }

    void LogMsg(){
        Debug.Log( "[OptionTrigger] " + this.name + " : " + "Condition : \n"
          + "STR : " + min_status.STR + " ~ " + max_status.STR
          + " INT : " + min_status.INT + " ~ " + max_status.INT
          + " HATE : " + min_status.HATE + " ~ " + max_status.HATE );
    }
}
