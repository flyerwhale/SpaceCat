using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UrchinFollow : MonoBehaviour {



    public GameObject player;//寻路目标
    public float timer;
    public bool follow = false;
    public PlayerMoving PlayerMoving;
    PlayerAttribute PlayerAttribute;
    public float reducetime ;
    

    private void Start()
    {

        player = GameObject.Find("Player");
        timer = 0;
        PlayerMoving = GameObject.Find("Player").GetComponent<PlayerMoving>();
        PlayerAttribute = GameObject.Find("Player").GetComponent<PlayerAttribute>();
        reducetime = 0;
    }

    private void Update()
    {
        if (follow == true) { 
       
        timer += Time.deltaTime;
        reducetime += Time.deltaTime;




            if (timer <= 6)
        {
                transform.position =  player.transform.position+Vector3.up;
                PlayerMoving.ChangeColor();

            }

        else
        {
                follow = false;
                PlayerMoving.ReturnColor();
                Destroy(this.gameObject);
        }
    }
        if (reducetime >= 1.5&&follow==true) {
            reducetime = 0;
            if (PlayerAttribute.RBlood <= 10)
            {
                PlayerAttribute.reduceBlood(10);
                timer = 7;
            }
            else {
                PlayerAttribute.reduceBlood(10);
            }
               
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            follow=true;
        }

    }





}
