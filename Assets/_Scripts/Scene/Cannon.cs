using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public GameObject CannonPrefab;      //子弹
    public float shootCD;                //攻击频率
    public float SetshootCD=3f;
    public float Bulletspeed = 600;     //子弹速度
    public int fireType;
                                         // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        shootCD -= Time.deltaTime;
        if (shootCD <= 0)
        {


            //PlaySound._audio.playShoot();//调用音效

            GameObject bullet = GameObject.Instantiate(CannonPrefab);   //实例化子弹预制体

            shootCD = SetshootCD;   //射击间隔



            if (fireType == 1)//上
            {
                bullet.transform.position = new Vector3(transform.position.x , transform.position.y+2);
                bullet.transform.Rotate(0, 0, -90);
                bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Bulletspeed);
            }

            if (fireType == 2)//下
            {
                bullet.transform.position = new Vector3(transform.position.x , transform.position.y-2);
                bullet.transform.Rotate(0, 0, 90);
                bullet.GetComponent<Rigidbody2D>().AddForce(-Vector3.up * Bulletspeed);
            }

            if (fireType == 3)//左
            {
                bullet.transform.position = new Vector3(transform.position.x - 2f, transform.position.y);
                bullet.GetComponent<Rigidbody2D>().AddForce(-Vector3.right * Bulletspeed);
            }

            if (fireType == 4)//右
            { 
            bullet.transform.position = new Vector3(transform.position.x + 1, transform.position.y);
            bullet.transform.localScale = new Vector3(-1, 1, 1);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Bulletspeed);
            }


        }
    }

}
