using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class Player : MonoBehaviour
{
    public GameObject Stair;
    public GameObject hp;
    public Image Stop;
    public Material CorrectMaterial;
    public Material WrongMaterial;

    Rigidbody playerRigidbody;

    private bool grounded = true;
    private int point = 0;
    private int is_init = 0;
    private float ColorAlpha = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(is_init == 0){
            AddListener();
        }
    }

    void AddListener(){
        var Controllers = FindObjectsOfType<VRTK_ControllerEvents>();
        for(int i = 0 ; i < Controllers.Length ; i++){
            var controller = Controllers[i];
            controller.TriggerPressed += SkipDialogue;
            controller.ButtonOnePressed += GripHp;
            controller.ButtonTwoPressed += Mute;
            controller.TouchpadPressed += Jump;
        }
        is_init = Controllers.Length;
    }

    void SkipDialogue(object o, ControllerInteractionEventArgs e){
        UIManager.Instance.Dialogue_Continue();
    }

    void GripHp(object o, ControllerInteractionEventArgs e)
    {   
        GameManager GM = GameManager.GM;
        Route path = GM.GetRoute();
        if( path == Route.End )
        {   
            if(ColorAlpha == 1.0f)
            {
                Stop.GetComponent<Image>().color = new Color(255,255,255,ColorAlpha);
                ColorAlpha = 0.5f;
                GameManager.GM.Stop = true;
            }
            else
            {
                Stop.GetComponent<Image>().color = new Color(255,255,255,ColorAlpha);
                ColorAlpha = 1.0f;
                GameManager.GM.Stop = false;
            }
            
        }
        else
        {
            hp.SetActive(false);
            Stair.SetActive(true);
        }
    }

    void Jump(object o, ControllerInteractionEventArgs e)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        if (grounded == true)
        {
            playerRigidbody.velocity += new Vector3(0, 5, 0); //添加加速度
            playerRigidbody.AddForce(Vector3.up * 20); //给刚体一个向上的力，力的大小为Vector3.up*mJumpSpeed
            grounded = false;
        }
        Debug.Log("now points: " + this.point);
    }

    void Mute(object o, ControllerInteractionEventArgs e){
        //AudioListener Audio = FindObjectOfType<AudioListener>();
        bool New_stat = !GameManager.GM.Voice;
        GameManager.GM.Voice = New_stat;
        AudioListener.volume = New_stat ? 1 : 0;
    }

    void OnCollisionEnter(Collision collision) {
        grounded = true;
        Renderer rend = collision.gameObject.GetComponent<Renderer>();
        if( rend )
        {
            if( rend.sharedMaterial.name == CorrectMaterial.name )
            {
                this.point += 50;
            }
            else if( rend.sharedMaterial.name == WrongMaterial.name )
            {
                this.point -= 100;
            }
        }
        Debug.Log("now points: " + this.point);
    }

    void OnTriggerEnter(Collider col)
    {
        if( col.gameObject.tag == "Obstacle" )
        {
            this.point -= 100;
            Destroy( col.gameObject );
        }
    }

    public int getPoints()
    {
        return this.point;
    }
}
