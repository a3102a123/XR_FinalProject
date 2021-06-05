using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDeadSceneManager : MonoBehaviour
{
    [HeaderAttribute("開始文本")]
    [SerializeField]
    private DialogueDisplayer Start_dia;

    [HeaderAttribute("行為選擇")]
    [SerializeField]
    private EventDecider ActionEvent;
    // Start is called before the first frame update
    void Start()
    {
        Start_dia.Activate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
