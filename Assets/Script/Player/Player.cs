using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Player : MonoBehaviour
{
    private int is_init = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(is_init == 0){
            AddListener();
        }
    }

    void AddListener(){
        var Controllers = FindObjectsOfType<VRTK_ControllerEvents>();
        for(int i = 0 ; i < Controllers.Length ; i++){
            var controller = Controllers[i];
            controller.TriggerPressed += SkipDialogue;
        }
        is_init = Controllers.Length;
    }

    void SkipDialogue(object o, ControllerInteractionEventArgs e){
        UIManager.Instance.Dialogue_Continue();
    }
}
