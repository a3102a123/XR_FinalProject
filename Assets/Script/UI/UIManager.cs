using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager  Instance;
    [HeaderAttribute("UI 顯示能力值物件設定")]
    [Tooltip("用來顯示GM的STR能力值")]
    public Text STR;
    public Text INT;
    public Text HATE;
    [HeaderAttribute("UI 文本視窗設定")]
    [Tooltip("用來顯示文本的UI Text Gameobject")]
    public Text TextWindow;
    [Tooltip("文本顯示時間")]
    public int Display_Time = 3;
    [Tooltip("轉場等待時間")]
    public int ChangeScene_Time = 2;
    [HeaderAttribute("道具icon")]
    public GameObject Smartphone;
    public GameObject Earphone;
    public GameObject Knife;
    public GameObject TestPaper;
    public GameObject TextUI;

    [HideInInspector]
    public DialogueDisplayer displayer;

    void Awake(){
        Instance = this;
        init();
    }
    void Update(){
        UpdateStatus();
        UpdateIcon();
        if( displayer != null )
        {
            TextUI.SetActive(true);
        }
    }
    void init(){
        TextWindow.text = "";
        STR.text = "None";
        INT.text = "None";
        HATE.text = "None";
        displayer = null;
        Smartphone.SetActive(false);
        Earphone.SetActive(false);
        Knife.SetActive(false);
        TestPaper.SetActive(false);
    }
    void UpdateStatus(){
        Status stat = GameManager.GM.GetStatus();
        STR.text = stat.STR.ToString();
        INT.text = stat.INT.ToString();
        HATE.text = stat.HATE.ToString();
    }
    void UpdateIcon(){
        GameManager GM = GameManager.GM; 
        Smartphone.SetActive(GM.Smartphone);
        Earphone.SetActive(GM.Earphone);
        Knife.SetActive(GM.Knife);
        TestPaper.SetActive(GM.TestPaper);
    }
    public void Dialogue_Continue(){
        if(displayer == null){
            Debug.Log("[UIManager] "+ this.name + " : No dialogue is played!");
        }
        else{
            displayer.continue_read();
        }
    }
}
