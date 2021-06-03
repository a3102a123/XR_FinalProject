using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BedSceneManager : MonoBehaviour
{
    [HeaderAttribute("探索結束")]
    [SerializeField]
    private bool is_sleeped = false;
    [SerializeField]
    private GameObject Pillow;
    [SerializeField]
    private EventTrigger Enabled_EventTrigger;
    // Update is called once per frame
    void Update()
    {
        if(is_sleeped){
            Enabled_EventTrigger.Enable();
        }
    }
    void isGrabPillow(){
        if(Pillow.GetComponent<InteractObj>().GetCount() > 0){
            is_sleeped = true;
        }
    }
}
