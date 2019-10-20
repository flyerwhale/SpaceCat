using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    public GameObject WaterEffect;  //接触水效果
    public PlayerMoving Player;
    public PlayerAttribute PlayerAttribute;
    public Die die;

 // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerMoving>();
        PlayerAttribute = GameObject.Find("Player").GetComponent<PlayerAttribute>();
        die = GameObject.Find("Player").GetComponent<Die>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlaySound._audio.playWaterDrown();
        Instantiate(WaterEffect, collision.transform.position + 0.2f * Vector3.down, transform.rotation);//落水效果
        die.playerDie();
        PlayerAttribute.reduceBlood(100);
        
    }
}
