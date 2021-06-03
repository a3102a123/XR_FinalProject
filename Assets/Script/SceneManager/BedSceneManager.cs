using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BedSceneManager : MonoBehaviour
{
    [HeaderAttribute("探索結束")]
    [SerializeField]
    private bool is_awake = false;
    [SerializeField]
    private GameObject Pillow;
    [SerializeField]
    private EventTrigger Enabled_EventTrigger;
    // Update is called once per frame
    void Update()
    {
        isGrabPillow();
        LeaveBed();
    }
    void isGrabPillow(){
        if( !is_awake && Pillow.GetComponent<InteractObj>().GetCount() > 0){
            DialogueDisplayer displayer;
            string filename = "Bed/Chapter2/Awake.txt";
            displayer = gameObject.AddComponent<DialogueDisplayer>() as DialogueDisplayer;
            displayer.Constructor(filename);
            // 反覆呼叫直到成功顯示文本
            if(displayer.Activate()){
                Enabled_EventTrigger.Enable();
                is_awake = true;
            }
        }
    }
    void LeaveBed(){
        string jump = "Bed/Chapter2/Jump.txt";
        string leave = "Bed/Chapter2/LeaveBed.txt";
        string result = Enabled_EventTrigger.GetEventResult();
        if( result == jump ){
            //change scene
        }
        else if(result == leave){
            //enable next select
        }
    }
}
