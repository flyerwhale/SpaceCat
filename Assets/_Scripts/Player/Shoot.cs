using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public Rigidbody2D player;  //主角刚体
    public Animator ani;       //动画机
    public GameObject bulletPrefab, bulletPrefabPlus,GoodBullet;//子弹
    public float speed = 1500;//子弹速度
    public float shootCD;     //射击间隔
    public bool canShoot;     //能否射击判断
    public float damage;
    public EscapeMenu escapeMenu;

    

   

    // Use this for initialization
    void Start () {
        //初始化
        ani = GameObject.Find("Player").GetComponent<Animator>( );
        shootCD = 0;
        canShoot=false;
        escapeMenu = GameObject.Find("Scripts").GetComponent<EscapeMenu>();

    }
	
	// Update is called once per frame
	void Update () {
        shootCD -= Time.deltaTime;

        
        //射击
        if (Input.GetMouseButtonDown(0) && shootCD <= 0 && canShoot == true&&escapeMenu.i==false)
        {
           
            PlaySound._audio.playShoot();//调用音效

            ani.SetTrigger("Shoot");
            //发射类型1子弹
            if (AwardBullet.BulletType == 1)
            {
              
                GameObject bullet = GameObject.Instantiate(bulletPrefab);
                
            shootCD = 0.5f;

            //子弹移动及方向
            if (player.transform.localScale.x > 0)
            {
                bullet.transform.position = new Vector3(player.transform.position.x+1.5f , player.transform.position.y);
                bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed);
            }
            else if (player.transform.localScale.x < 0)
            {
                bullet.transform.position = new Vector3(player.transform.position.x - 1.5f, player.transform.position.y);
                bullet.GetComponent<Rigidbody2D>().AddForce(-Vector3.right * speed);
            }
        }
            //发射类型2子弹
            if (AwardBullet.BulletType == 2)
            {

                GameObject bullet = GameObject.Instantiate(bulletPrefabPlus);

                shootCD = 0.3f;
                //子弹移动及方向
                if (player.transform.localScale.x > 0)
                {
                    bullet.transform.position = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y);
                    bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed);
                }
                else if (player.transform.localScale.x < 0)
                {
                    bullet.transform.position = new Vector3(player.transform.position.x - 1.5f, player.transform.position.y);
                    bullet.GetComponent<Rigidbody2D>().AddForce(-Vector3.right * speed);
                }
            }
            //发射类型3子弹
            if (AwardBullet.BulletType == 3)
            {

                GameObject bullet = GameObject.Instantiate(GoodBullet);

                shootCD = 0.3f;
                //子弹移动及方向
                if (player.transform.localScale.x > 0)
                {
                    bullet.transform.position = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y);
                    bullet.transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
                    bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed);
                }
                else if (player.transform.localScale.x < 0)
                {
                    bullet.transform.position = new Vector3(player.transform.position.x - 1.5f, player.transform.position.y);
                    bullet.GetComponent<Rigidbody2D>().AddForce(-Vector3.right * speed);
                }
            }
        }
    }






}
