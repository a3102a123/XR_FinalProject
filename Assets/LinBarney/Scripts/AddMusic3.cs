using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMusic3 : MonoBehaviour
{
    public static AudioSource source;
    public GameObject target;
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
        if (source.isPlaying){
            Debug.Log("GG");
            target.SetActive(false);
        }
        if(source.volume<1f){
            target.SetActive(true);
        }
        // if (!source.isPlaying){
        //     Debug.Log("GG2");
        //     target.SetActive(true);
        // }
    }

    IEnumerator playAudio()
    {
        //AudioSource audio = GetComponent<AudioSource>();
       
        source.volume = 0.3f;

        while (source.volume < 1f)
        {
            source.volume = Mathf.Lerp(source.volume, 1.09f, 0.4f * Time.deltaTime);
            yield return 1f;
        }

        yield return new WaitForSeconds(12.5f);

        while (source.volume > 0f)
        {
            source.volume = Mathf.Lerp(source.volume, 0f, 0.4f * Time.deltaTime);
            yield return 0f;
        }
    }
}
