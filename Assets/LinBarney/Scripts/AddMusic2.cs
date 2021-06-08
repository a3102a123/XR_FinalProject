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

        StartCoroutine(AnimateMusicCrossfade(1));
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
       

        // if(flag == 1)
        // {
        //     this.GetComponent<AudioSource>().clip = audios[0];
        //     this.GetComponent<AudioSource>().Play();
        //     flag = 0;
        // }
    }
    IEnumerator AnimateMusicCrossfade(float duration){
        float percent = 0;
        
        while(percent < 1){
            percent += Time.deltaTime * 1 / duration;
            this.GetComponent<AudioSource>().volume = Mathf.Lerp(0,0.3f,percent);
            this.GetComponent<AudioSource>().volume = Mathf.Lerp(0.3f,0,percent);
            yield return null;
        }
    }
}
