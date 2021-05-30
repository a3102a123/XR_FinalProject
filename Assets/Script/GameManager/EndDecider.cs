using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDecider : MonoBehaviour
{
    [HeaderAttribute("設定各條路線的結局")]
    public EndCondition [] End_list = new EndCondition[3];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 鍵盤遊戲的成功失敗由flag is_fail來傳入
    // is_fail = flase means success
    // is_fail = true means fail
    public void DecideEnd(bool is_fail){
        int i;
        EndCondition End;
        DialogueDisplayer displayer;
        string filename;
        for(i = 0 ; i < End_list.Length ; i++){
            End = End_list[i];
            if(End.EndRoute == GameManager.GM.GetRoute()){
                displayer = gameObject.AddComponent<DialogueDisplayer>() as DialogueDisplayer;
                if(is_fail){
                    filename = End.fail_filename;
                }
                else{
                    filename = End.success_filename;
                }
                displayer.Constructor(filename);
                // test whether displayer successful activate
                if(!displayer.Activate()){
                    Debug.Log("[EndDecider] " + this.name + "Event initial failed!");
                    Destroy(displayer);
                };
                break;
            }
        }
        if(i == End_list.Length){
            Debug.Log("[EndDecider] " + this.name + "No End meet GM route!");
        }
    }
}
