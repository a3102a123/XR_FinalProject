using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamplerunManager : MonoBehaviour
{
    public GameObject wideObstacle;
    public GameObject heightObstacle;
    public Transform startCenter;
    public float Ins_time = 1; 
    public float h = 3f;
    public float v = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Ins_Objs", Ins_time, Ins_time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ins_Objs()
    {
        int type = Random.Range(0, 2);
        if (type == 0)
        {
            float r_v = Random.Range(0, v);
            Vector3 myVector = new Vector3(0, r_v, 0);

            Instantiate( wideObstacle, startCenter.transform.position+myVector, Quaternion.Euler (0f, 0f, 0f));
        }
        else
        {
            float r_h = Random.Range(-h, h);
            Vector3 myVector = new Vector3(r_h, v/2, 0);

            Instantiate( heightObstacle, startCenter.transform.position+myVector, Quaternion.Euler (0f, 0f, 0f));
        }
    }
}
