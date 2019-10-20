using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpNumber : MonoBehaviour
{
    public int jumpNumber = 2;              //跳跃计数器
    public GameObject TouchTheGroundEffect;  //接触地面效果
    public bool reduce = true;                                        
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && reduce == true)
        {
            jumpNumber--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if ( collision.gameObject.tag == "Award")
        {
            
            jumpNumber = 2;

        }
        if (collision.gameObject.tag == "Ground" )
        {
            jumpNumber = 2;
            Instantiate(TouchTheGroundEffect, transform.position + 0.5f * Vector3.down + 0.2f * Vector3.left, transform.rotation);

        }
        
    }

}
