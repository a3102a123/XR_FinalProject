using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    HighlightsFX HighlightsFX;
    Transform cam;
    // Use this for initialization
    void Start()
    {
        HighlightsFX = GameObject.Find("Main Camera").GetComponent<HighlightsFX>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        raycastObj();
    }

    void raycastObj()
    {
        updateSelected();
    }
    void updateSelected()
    {
        HighlightsFX.ClearOutlineData();
        Renderer renderer = this.GetComponent<Renderer>();
        List<Renderer> one = new List<Renderer>();
        one.Add(renderer);
        HighlightsFX.AddRenderers(one);
    }

    void roateThis(GameObject n)
    {
        n.transform.localEulerAngles += Vector3.up * Time.deltaTime * 100f;
    }
}
