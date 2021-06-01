using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPoint : MonoBehaviour
{
    public void OnTriggerEnter(Collider other){
        var select_list = FindObjectsOfType<SelectEvent>();
        for(int i = 0 ; i < select_list.Length ; i++){
            var select = select_list[i];
            select.BroadcastMessage("Selected",this.gameObject);
        }
    }
}
