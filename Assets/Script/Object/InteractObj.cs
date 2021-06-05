using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

[RequireComponent(typeof(OptionTrigger))]
[RequireComponent(typeof(DialogueDisplayer))]
public class InteractObj : VRTK_InteractableObject
{
    [HeaderAttribute("物件所代表的選項")]
    [SerializeField]
    [Tooltip("該物件設定影響的能力值變化以及觸發選項的能力值限制")]
    private OptionTrigger Option;
    [SerializeField]
    [Tooltip("使取該物件時所顯示的文本")]
    private DialogueDisplayer Dialogue;
    [SerializeField]
    [Tooltip("是否使物件被grab後不被抓取")]
    private bool is_touch;

    [HeaderAttribute("Private Variable")]
    [Tooltip("顯示來幫忙debug，不受設定影響")]
    [SerializeField]
    private int grab_count = 0;

    Vector3 ori_position;
    void Start(){
        grab_count = 0;
        holdButtonToGrab = is_touch;
        ori_position = gameObject.transform.position;
    }

    protected override void  Update(){
        base.Update();
        if(is_touch){
            gameObject.transform.position = ori_position;
        }
    }
    
    public override void Grabbed(VRTK_InteractGrab currentGrabbingObject = null){
        if(Option == null || Dialogue == null){
            Debug.Log("[InteractObject] " + this.name + " : There is a object which isn't setted!");
        }
        // 文本可以被多次讀取
        if(!Dialogue.Activate()){
             Debug.Log("[InteractObject] " + this.name + " : Display dialogue failed. Stop!");
        }
        // 文本成功顯示後再設定能力值，能力值只會被設定一次
        if(Option.GetFinish()){
            Debug.Log("[InteractObject] " + this.name + " : option is triggered again!");
        }
        else{
            Option.SetFinish();
        }
        base.Grabbed(currentGrabbingObject);
        grab_count += 1;
    }
    public int GetCount(){
        return grab_count;
    }
    void Reset() {
        Option = GetComponent<OptionTrigger>();
        Dialogue = GetComponent<DialogueDisplayer>();
        this.isGrabbable = true;
        this.holdButtonToGrab = false;
    }
}
