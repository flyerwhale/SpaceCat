using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoving : MonoBehaviour {

    float MovingDirection = 0;                     //移动方向
    public float MovingTime;                       //移动时间
    public float speed = 1;                        //速度
    public bool i = false;
    // Use this for initialization
    void Start () {

        MovingTime = 3;

    }
	
	// Update is called once per frame
	void Update () {
        MovingDirection += Time.deltaTime;

        


        //左移动
        if (MovingDirection <= MovingTime)
        {
            
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            
            }
   

        //右移动
        else if (MovingDirection >= MovingTime && MovingDirection <= MovingTime * 2)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            
            
        }
        //归零计数
        else
        {
            MovingDirection = 0;
        }
    }
}
