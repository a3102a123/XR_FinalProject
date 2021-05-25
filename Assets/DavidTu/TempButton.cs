using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempButton : MonoBehaviour
{
    public OptionTrigger trigger;
    public GameObject option_obj;
    // Start is called before the first frame update
    void Start()
    {
        option_obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        display();
    }
    void display(){
        if(option_obj.activeSelf == false){
            if(trigger.Check()){
                option_obj.SetActive(true);
                Debug.Log(this.name + " Active");
            }
        }
        else{
            if(!trigger.Check()){
                option_obj.SetActive(false);
                Debug.Log(this.name + " Disable");
            }
        }
    }
}
