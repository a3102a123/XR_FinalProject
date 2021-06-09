using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherSceneManager : MonoBehaviour
{
    [HeaderAttribute("開始文本")]
    [SerializeField]
    private DialogueDisplayer Start_dia;
    [HeaderAttribute("選擇文本")]
    //[SerializeField]
    //private DialogueDisplayer Fight;
    [SerializeField]
    private SelectEvent RunAway;
    [HeaderAttribute("Private Variable")]
    [SerializeField]
    private string End;

    private bool is_init = false;
    private bool is_change = false;
    // Start is called before the first frame update
    void Start()
    {
        is_change = false;
        End = "";
        Start_dia.Activate();
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_init && GameManager.GM != null)
        {
            GameManager.GM.Stop = false;
            is_init = true;
        }
        if (is_init && End == "")
        {
            if (GameManager.GM.Stop)
            {
                //Fight.Activate();
                RunAway.enabled = false;
                End = "Fight";
            }
            else if (RunAway.GetResult() != "")
            {
                //Fight.enabled = false;
                End = "RunAway";
            }
        }
        else if(End != "" && UIManager.Instance.displayer == null)
        {
            if(End == "Fight" && !is_change)
            {
                is_change = GameManager.GM.ChangeScene("Final_video");
            }
            else if (End == "RunAway" && !is_change)
            {
                is_change = GameManager.GM.ChangeScene("Final_video_3");
            }
        }
    }
}
