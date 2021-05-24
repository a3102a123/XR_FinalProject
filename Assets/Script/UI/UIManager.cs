using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager  Instance;
    [HeaderAttribute("UI 文本視窗設定")]
    [Tooltip("用來顯示文本的UI Text Gameobject")]
    public Text TextWindow;
    [Tooltip("文本顯示時間")]
    public int Display_Time = 3;

    void Awake(){
        Instance = this;
        DontDestroyOnLoad(this);
        init();
    }
    void init(){
        TextWindow.text = "";
    }
}
