using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBoss : MonoBehaviour {
    public bool attack=false;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            attack = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("1");
            attack = true;
        }
    }




}
