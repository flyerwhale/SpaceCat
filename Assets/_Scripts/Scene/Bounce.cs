using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {
    public Animator bounce;
	// Use this for initialization
	void Start () {
		bounce = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlaySound._audio.playBounce();//调用音效
            bounce.SetTrigger("Bounce");
            
        }
    }
}
