using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class show : MonoBehaviour
{
    public void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.layer);
    }
}
