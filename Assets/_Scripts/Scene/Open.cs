using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour {

    public PlayerAttribute PlayerAttribute;
    public GameObject Tips;
    public Animator ani;

    // Use this for initialization
    void Start()
    {
       
        PlayerAttribute = GameObject.Find("Player").GetComponent<PlayerAttribute>();
        ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && PlayerAttribute.Key >= 9)
        {
            ani.SetTrigger("OPEN");

        }
        if (collision.gameObject.tag == "Player" && PlayerAttribute.Key < 9)
        {
            Tips.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Tips.SetActive(false);
        }

    }

}
