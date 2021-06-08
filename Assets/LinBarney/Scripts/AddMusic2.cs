using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMusic2 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audios;
    public int flag =0;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().clip = audios[0];
        this.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {  
        if (Input.GetKeyDown (KeyCode.H))  
        {  
            this.GetComponent<AudioSource>().clip = audios[1];
            this.GetComponent<AudioSource>().Play();
            flag = 1;
        } 
        // if(audioSource.isPlaying == false)
        // {
        //     Debug.Log("Finish");
        //     this.GetComponent<AudioSource>().clip = audios[0];
        //     this.GetComponent<AudioSource>().Play();
        // }
        
        // if(flag == 1)
        // {
        //     this.GetComponent<AudioSource>().clip = audios[0];
        //     this.GetComponent<AudioSource>().Play();
        //     flag = 0;
        // }
    }
}
