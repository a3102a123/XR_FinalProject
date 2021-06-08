using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBackgroundMusic : MonoBehaviour
{
    private AudioSource bgMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        bgMusic = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource> ();
    }

    void OnDisable()
    {
        bgMusic.UnPause();
    }
}
