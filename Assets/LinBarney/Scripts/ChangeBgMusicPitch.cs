using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBgMusicPitch : MonoBehaviour
{
    public float pitch;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource source = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
        source.Stop();
        source.pitch = pitch;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
