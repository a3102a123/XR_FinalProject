using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5;
    public Material CorrectMaterial;
    public Material WrongMaterial;

    Rigidbody playerRigidbody;

    private Transform transform;
    private bool grounded = true;
    private int point = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform = this.GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump")) {
            if (grounded == true)
            {
                playerRigidbody.velocity += new Vector3(0, 5, 0); //添加加速度
                playerRigidbody.AddForce(Vector3.up * 50); //给刚体一个向上的力，力的大小为Vector3.up*mJumpSpeed
                grounded = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        grounded = true;
        Renderer rend = collision.gameObject.GetComponent<Renderer>();
        if( rend.sharedMaterial.name == CorrectMaterial.name )
        {
            this.point += 50;
        }
        else if( rend.sharedMaterial.name == WrongMaterial.name )
        {
            this.point -= 100;
        }
        Debug.Log("point: " + this.point);
    }

    void OnTriggerEnter(Collider col)
    {
        if( col.gameObject.tag == "Obstacle" )
        {
            this.point -= 100;
            Destroy( col.gameObject );
        }
        Debug.Log("point: " + this.point);
    }
}
