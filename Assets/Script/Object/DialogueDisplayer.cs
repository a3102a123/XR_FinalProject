using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class DialogueDisplayer : MonoBehaviour
{
    private Text text_window = null;
    [HeaderAttribute("文本檔案路徑")]
    [Tooltip("輸入以Dialogue資料夾為根目錄的相對路徑")]
    public string dialogue_filename;
    [HeaderAttribute("Private flag")]
    [SerializeField]
    [Tooltip("顯示來幫忙debug，不受設定影響")]
    private bool is_act = false;

    private bool is_show = false;
    private bool is_read = false;
    private string root_path = "./Assets/Dialogue/";
    private string path;
    System.IO.StreamReader file;
    private int dis_time;

    int i ;
    string str;

    // fur construct in script, prevent Strat act after script calling class function
    void Awake(){
        //Debug.Log("[DialogueDisplayer] " + this.name + " : " + (UIManager.Instance));
        //init();
    }
    void Start(){
        if(text_window == null){
            init();
        }
    }
    void Update()
    {
        //Debug.Log("[DialogueDisplayer] " + this.name + " : is_act : " + is_act);
        if(is_act){
            if(is_show)
            {
                if(is_read){
                    if((str = file.ReadLine()) != null){ 
                        text_window.text = str;
                        is_read = false;
                        Invoke("wait",dis_time);
                    }
                    else{
                        is_show = false;
                    }
                }
            }
            // end the dialogue
            if(!is_show){
                stop();
            }
        }
    }

    // 向 UIManager 確認 dialogue 的 text window 是否被使用，沒有的話則註冊下來使用
    bool Register(){
        UIManager UI = UIManager.Instance;
        // text window 沒有被使用，註冊下來使用
        if(UI.displayer == null){
            // Debug.Log("[DialogueDisplayer] " + this.name + " : Registed!!");
            UI.displayer = this;
            return true;
        }
        // text window 有人在使用，放棄activate，需要被重新觸發才會出現dialogue
        else if(UI.displayer != this){
            Debug.Log("[DialogueDisplayer] " + this.name + " : Text window is used by " + UI.displayer + "! Needing to activate this dialogue again!");
            return false;
        }
        return true;
    }

    void init(){
        text_window = UIManager.Instance.TextWindow;
        dis_time = UIManager.Instance.Display_Time;
        is_show = true;
        is_read = true;
        is_act = false;
        root_path = "./Assets/Dialogue/";
    }
    void open_file(){
        path = root_path + dialogue_filename;
        Debug.Log("[DialogueDisplayer] " + this.name +" : Loading " + path);
        file = new System.IO.StreamReader(@path);
    }

    void stop(){
        text_window.text = "";
        UIManager.Instance.displayer = null;
        file.Close();
        is_act = false;
    }
    //default dialogue display time,continue when time out
    void wait(){
        Debug.Log("Timeout");
        is_read = true;
    }

    //controller trigger dialogue continue
    // should be trigger when get the controller button input
    public void continue_read(){
        CancelInvoke("wait");
        is_read = true;
    }
    // Activate this dialogue
    // 回傳是否註冊成功，失敗的話要 reactivate
    public bool Activate(){
        if(!is_act && Register()){
            // prevent reinitial in Start() when create by other script
            if(text_window == null){
                init();
            }
            open_file();
            is_act = true;
            is_show = true;
            return true;
        }
        else{
            return false;
        }
    }
    // for button to activate
    public void btn_Activate(){
        Activate();
    }
    /*public void OnTriggerEnter(Collider other)
    {
        Debug.Log("[DialogueDisplayer] " + this.name + " : Trigger Acitvate!");
        Activate();
    }*/

    // Construct function for MonoBehaviour
    public void Constructor(string path){
        dialogue_filename = path;
    }
}
