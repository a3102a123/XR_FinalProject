using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class show : VRTK_InteractableObject
{
    [HeaderAttribute("我的變數")]
    [SerializeField]
    private string str;
    public override void Grabbed(VRTK_InteractGrab currentGrabbingObject = null){
        Debug.Log("Grab : " + this.name);
        base.Grabbed(currentGrabbingObject);
    }
}
