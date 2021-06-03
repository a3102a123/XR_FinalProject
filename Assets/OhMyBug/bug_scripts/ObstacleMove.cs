using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public int Speed;
    public float Destroy_time = 5;

    private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = this.GetComponent<Transform>();
        Destroy( this.gameObject, Destroy_time );
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -Speed*Time.deltaTime);
    }
}
