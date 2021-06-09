using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMusic3 : MonoBehaviour
{
    public static AudioSource source;
    public GameObject target;
    public bool is_mute = false;
    public bool fade = true;
    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.FindGameObjectWithTag("OtherMusic").GetComponent<AudioSource>();
        //source.Stop();
        //source.pitch = pitch;
        source.Play();
        if (fade)
        {
            StartCoroutine(playAudio());
        }
        
        // gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // if (source.isPlaying){
        //     //Debug.Log("GG");
        //     target.SetActive(false);
        // }
        if(is_mute && source.volume < 0.2f)
        {
            target.SetActive(true); 
            this.gameObject.SetActive(false);
        }
        // if (!source.isPlaying){
        //     Debug.Log("GG2");
        //     target.SetActive(true);
        // }
    }

    IEnumerator playAudio()
    {
        //AudioSource audio = GetComponent<AudioSource>();
       
        source.volume = 0.2f;

        while (source.volume < 0.8f)
        {
            source.volume = Mathf.Lerp(source.volume, 0.89f, 0.3f * Time.deltaTime);
            yield return 0.8f;
        }

        yield return new WaitForSeconds(11.5f);

        while (source.volume > 0f)
        {
            source.volume = Mathf.Lerp(source.volume, 0f, 0.6f * Time.deltaTime);
            yield return 0f;
        }
    }
}
