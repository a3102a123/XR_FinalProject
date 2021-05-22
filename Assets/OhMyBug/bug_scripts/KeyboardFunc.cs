using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardFunc : MonoBehaviour
{
    public Material[] material;
    public GameObject[] keyboard;
    public float Interval;

    private float total_time = 0;

    // Start is called before the first frame update
    void Start()
    {
        resetKeyboard();
        changeKeyboard();
    }

    // Update is called once per frame
    void Update()
    {
        this.total_time += (Time.deltaTime);
        if( total_time > Interval )
        {
            resetKeyboard();
            changeKeyboard();
            this.total_time -= Interval;
        }
    }

    void resetKeyboard()
    {
        for( int i = 0; i < 15; i++ )
        {
            Renderer rend = keyboard[i].GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = material[2];
        }
    }

    void changeKeyboard()
    {
        int i = Random.Range(0, 15); // correct
        int j = Random.Range(0, 15); // wrong
        int k = Random.Range(0, 15); // wrong

        Renderer rend1 = keyboard[i].GetComponent<Renderer>();
        Renderer rend2 = keyboard[j].GetComponent<Renderer>();
        Renderer rend3 = keyboard[k].GetComponent<Renderer>();

        rend1.enabled = true;
        rend2.enabled = true;
        rend3.enabled = true;

        rend2.sharedMaterial = material[1];
        rend3.sharedMaterial = material[1];
        rend1.sharedMaterial = material[0];
    }
}
