using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDeadSceneManager : MonoBehaviour
{
    [HeaderAttribute("開始文本")]
    [SerializeField]
    private DialogueDisplayer Start_dia_B;
    [SerializeField]
    private DialogueDisplayer Start_dia_C;

    [HeaderAttribute("探索結束")]
    [SerializeField]
    private GameObject EarPhone;

    private bool is_change = false;
    private Route route;
    // Start is called before the first frame update
    void Start()
    {
        Status stat = new Status(0, 0, 10);
        // 死掉 + 10 Hate
        GameManager.GM.ChangeStatus(stat);
        is_change = false;
        route = GameManager.GM.GetRoute();
        if(route == Route.B)
        {
            Start_dia_B.Activate();
        }
        else if(route == Route.C)
        {
            Start_dia_C.Activate();
        }
        else
        {
            Debug.Log("[AfterDeadsceneManager] " + this.name + " : No Route meet to start.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrabbed();
        Leave();
    }
    void isGrabbed(){
        GameManager GM = GameManager.GM;
        if(EarPhone.GetComponent<InteractObj>().GetCount() == 1){
            GM.Earphone = true;
            //Change Scene
        }
    }
    void Leave()
    {
        if (EarPhone.GetComponent<InteractObj>().GetCount() >= 1)
        {
            if (!is_change)
            {
                Debug.Log("ToTable Route C");
                is_change = GameManager.GM.ChangeScene("ToTable");
            }
        }
        else if(route == Route.B)
        {
            if (!is_change)
            {
                Debug.Log("ToTable Route B");
                is_change = GameManager.GM.ChangeScene("ToTable");
            }
        }
    }
}
