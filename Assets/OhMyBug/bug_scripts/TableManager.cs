using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    public DialogueDisplayer Dia_A;
    public DialogueDisplayer Dia_B;
    public DialogueDisplayer Dia_C;
    public DialogueDisplayer Dia_C_h;
    public InteractObj Obj;
    public GameObject Stair_hand;
    public GameObject Stair_keyboard;

    private float t = 10;
    private bool scene_flag = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int grab = Obj.GetCount();
        if( grab >= 1 )
        {
            Stair_hand.SetActive(false);
            Stair_keyboard.SetActive(true);

            if (scene_flag == false)
            {
                GameManager GM = GameManager.GM;
                scene_flag = GM.ChangeScene("Table");
            }
        }
        if( t > 9 )
        {
            GameManager GM = GameManager.GM;
            Route path = GM.GetRoute();
            Status st = GM.GetStatus();

            if( path == Route.A )
            {
                Dia_A.Activate();
            }
            else if ( path == Route.B )
            {
                Dia_B.Activate();
            }
            else if ( path == Route.C && st.HATE == 0)
            {
                Dia_C.Activate();
            }
            else
            {
                Dia_C_h.Activate();
            }

            t -= 1; 
        }
    }
}
