using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMusicByScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audios;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {  
        if (Input.GetKeyDown (KeyCode.H))  
        {  
            audioSource.Play(); 
        }  
    }
}
