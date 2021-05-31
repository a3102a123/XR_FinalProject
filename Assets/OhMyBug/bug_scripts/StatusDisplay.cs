using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StatusDisplay : MonoBehaviour, IPointerClickHandler
{
    public Text Size;
    public Text Strength;
    public Text IQ;
    public Text Points;
    public const int maxHealth = 100;

    public RectTransform HealthBar,Hurt;
    public GameObject Stair;
    public GameObject hp;
    public PlayerControl player;

    // Character object here

    // temp status
    private int size = 3;
    private int str = 100;
    private int iq = 100;
    public int currentHealth = maxHealth;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        int p = player.getPoints();
        Size.text = "Size: " + size;
        Strength.text = "Strength: " + str;
        IQ.text = "IQ: " + iq;
        Points.text = "Points: " + p;

        // maybe get these from character's api

        if (Input.GetKeyDown(KeyCode.H))
        {
          // also need another way to get current health
          currentHealth = currentHealth - 10;
        }
        HealthBar.sizeDelta = new Vector2(currentHealth, HealthBar.sizeDelta.y);
        if (Hurt.sizeDelta.x > HealthBar.sizeDelta.x)
        {
          Hurt.sizeDelta += new Vector2(-1, 0)*Time.deltaTime*10;
        }
    }

    // if(VRInput.GetDown)
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        if(eventData.pointerCurrentRaycast.gameObject.name == "LifePoint" || eventData.pointerCurrentRaycast.gameObject.name == "Hurt" || eventData.pointerCurrentRaycast.gameObject.name == "HealthBar")
        {
          hp.SetActive(false);
          Stair.SetActive(true);
        }
    }
}
