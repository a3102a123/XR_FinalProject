using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractObj : VRTK_InteractableObject
{
    [HeaderAttribute("物件所代表的選項")]
    [SerializeField]
    [Tooltip("該物件設定影響的能力值變化以及觸發選項的能力值限制")]
    private OptionTrigger Option;
    [SerializeField]
    [Tooltip("使取該物件時所顯示的文本")]
    private DialogueDisplayer Dialogue;
    
    public override void Grabbed(VRTK_InteractGrab currentGrabbingObject = null){
        if(Option == null || Dialogue == null){
            Debug.Log("[InteractObject] " + this.name + " : There is a object which isn't setted!");
        }
        // 文本可以被多次讀取
        if(!Dialogue.Activate()){
             Debug.Log("[InteractObject] " + this.name + " : Display dialogue failed. Stop!");
        }
        // 文本成功顯示後再設定能力值，能力值只會被設定一次
        Debug.Log("Triggered ? : " + Option.GetFinish());
        if(Option.GetFinish()){
            Debug.Log("[InteractObject] " + this.name + " : option is triggered again!");
        }
        else{
            Option.SetFinish();
        }
        base.Grabbed(currentGrabbingObject);
    }
    void Reset() {
        Option = GetComponent<OptionTrigger>();
        Dialogue = GetComponent<DialogueDisplayer>();
        this.isGrabbable = true;
        this.holdButtonToGrab = false;
    }
}
