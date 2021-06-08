using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDeadSceneManager : MonoBehaviour
{
    [HeaderAttribute("開始文本")]
    [SerializeField]
    private DialogueDisplayer Start_dia;

    [HeaderAttribute("探索結束")]
    [SerializeField]
    private GameObject EarPhone;
    // Start is called before the first frame update
    void Start()
    {
        Start_dia.Activate();
    }

    // Update is called once per frame
    void Update()
    {
        isGrabbed();
    }
    void isGrabbed(){
        GameManager GM = GameManager.GM;
        if(EarPhone.GetComponent<InteractObj>().GetCount() == 1){
            GM.Earphone = true;
            //Change Scene
        }
    }
}
