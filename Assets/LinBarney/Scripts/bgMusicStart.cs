using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMusicStart : MonoBehaviour
{
    public static AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();
        //source.Stop();
        //source.pitch = pitch;
        source.Play();

        StartCoroutine(playAudio());
        
        // gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator playAudio()
    {
        //AudioSource audio = GetComponent<AudioSource>();
       
        source.volume = 0.2f;

        while (source.volume < 0.8f)
        {
            source.volume = Mathf.Lerp(source.volume, 0.89f, 0.6f * Time.deltaTime);
            yield return 0.8f;
        }
    }
}
