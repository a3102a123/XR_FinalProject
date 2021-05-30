using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamplerunManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject wideObstacle;
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
        int type = Random.Range(0, 5);
        if (type == 4)
        {
            float r_v = Random.Range(0, v);
            Vector3 myVector = new Vector3(0, r_v, 0);

            Instantiate( wideObstacle, startCenter.transform.position+myVector, Quaternion.Euler (90f, 0f, 0f));
        }
        else
        {
            float r_h = Random.Range(-h, h);
            float r_v = Random.Range(0, v);
            Vector3 myVector = new Vector3(r_h, r_v, 0);

            Instantiate( obstacle, startCenter.transform.position+myVector, Quaternion.Euler (90f, 0f, 0f));
        }
    }
}
