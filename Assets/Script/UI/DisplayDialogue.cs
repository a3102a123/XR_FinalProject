using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class DisplayDialogue : MonoBehaviour
{
    private Text text_window;
    [HeaderAttribute("文本檔案路徑")]
    [Tooltip("輸入以Dialogue資料夾為根目錄的相對路徑")]
    public string dialogue_filename;

    private bool is_show = false;
    private bool is_read = false;
    private bool is_act = false;
    private string root_path = "./Assets/Dialogue/";
    private string path;
    System.IO.StreamReader file;
    private int dis_time;

    int i ;
    string str;

    void Start(){
        Debug.Log("[DisplayDialogue] " + this.name + " : " + (UIManager.Instance));
        init();
    }
    void Update()
    {
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

    void init(){
        text_window = UIManager.Instance.TextWindow;
        dis_time = UIManager.Instance.Display_Time;
        is_show = true;
        is_read = true;
        is_act = false;
    }
    void open_file(){
        path = root_path + dialogue_filename;
        Debug.Log("[DisplayDialogue] " + this.name +" : Loading " + path);
        file = new System.IO.StreamReader(@path);
    }

    void stop(){
        text_window.text = "";
        file.Close();
        is_act = false;
    }
    //default dialogue display time,continue when time out
    void wait(){
        is_read = true;
    }

    //controller trigger dialogue continue
    public void continue_read(){
        is_read = true;
    }
    // Activate this dialogue
    public void Activate(){
        open_file();
        is_act = true;
        is_show = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("[DisplayDialogue] " + this.name + " : Trigger Acitvate!");
        Activate();
    }
}
