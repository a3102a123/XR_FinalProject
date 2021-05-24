using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionTrigger : MonoBehaviour
{
    [HeaderAttribute("選項是否被觸發並完成")]
    [SerializeField]
    private bool is_finish = false;

    [HeaderAttribute("在哪個章節觸發")]
    [SerializeField]
    [Tooltip("設為 ANY 在任意round觸發")]
    private Round round;
    [SerializeField]
    [Tooltip("設為 ANY 在任意stage觸發")]
    private Stage stage;

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

    [HeaderAttribute("完成後是否使影響GM的章節選項(2選1優先處理dead)")]
    [Tooltip("勾選後GM的stage會往前進1")]
    public bool is_next = false;
    [Tooltip("勾選後GM的round會往前進1，並將stage reset")]
    public bool is_dead = false;
    

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
        if(Check()){
            if(!is_finish){
                is_finish = true;
                GameManager.GM.ChangeStatus(effect_status);
                NextChapter();
            }
            else{
                Debug.Log( "[OptionTrigger] " + this.name + " : is already finished!");
            }
        }
        return is_finish;
    }
    void NextChapter(){
        if(is_dead){
            GameManager.GM.DeadEvent();
        }
        else if(is_next){
            GameManager.GM.NextStage();
        }
    }
    // 檢查是否符合章節設定及能力值限制
    bool Check(){
        Debug.Log( "[OptionTrigger] " + this.name + " : " + "Condition : " + "Round : " + round + " Stage : " + stage);
        if(CheckChapter()){
            return CheckLimit();
        }
        return false;
    }
    // UI 或選項 可以使用該 function 判斷是否要顯現
    public bool CheckChapter(){
        Round GM_round = GameManager.GM.GetRound();
        Stage GM_stage = GameManager.GM.GetStage();
        // 在特定的回合及事件觸發
        if( (round == GM_round) && (stage == GM_stage) ){
            return true;
        }
        // 在任意回合的特定事件觸發
        else if( (round == Round.ANY) && (stage == GM_stage) ){
            return true;
        }
        // 在特定回合的任意事件觸發
        else if( (round == GM_round) && (stage == Stage.ANY) ){
            return true;
        }
        // 隨時隨地都能觸發
        else if ( (round == Round.ANY) && (stage == Stage.ANY) ){
            return true;
        }
        return false;
    }
    public bool CheckLimit(){
        if(is_limit){
            // check STR
            if(min_status.STR != -1 || max_status.STR != -1){
                int value = GameManager.GM.GetStatus().STR;
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
                int value = GameManager.GM.GetStatus().INT;
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
                int value = GameManager.GM.GetStatus().HATE;
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
        else{
            // 沒有能力值限制回傳true
            return true;
        }
    }
    // function for button to trigger
    public void ButtonFinish(){
        SetFinish();
    }
}
