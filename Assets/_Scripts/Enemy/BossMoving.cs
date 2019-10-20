using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoving : MonoBehaviour {

    public GameObject player;            //主角
    public float distance = 20;          //危险距离
    public float speed = 1;              //速度
    public Rigidbody2D Boss;            //刚体
    public GameObject bulletPrefab;      //子弹
    public float Bulletspeed = 1500;     //子弹速度
    public float shootCD;                //攻击频率
    public float HP;
    public float damage;
    public GameObject DamageEffect;
    public int shootDistance;
    public float i;
    public GameObject award;



    void Start()
    {
        //初始化
        Boss = this.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");




    }

    // Update is called once per frame
    void Update()
    {

        damage = GameObject.Find("Shoot").GetComponent<Shoot>().damage;
        shootCD -= Time.deltaTime;
        float dis = Vector3.Distance(player.transform.position, transform.position);//与主角的距离

        if (dis < distance && Mathf.Abs(player.transform.position.y - transform.position.y) <= shootDistance)//距离小于危险距离，朝人物移动
        {
            //朝向
            if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1.5f, 1.5f, 1);
            }
            else if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(1.5f, 1.5f, 1);
            }
            EnemyShoot();    //调用射击方法
        }

    }

    
    //射击
    public void EnemyShoot()
    {
        if (shootCD <= 0)
        {

            if (Mathf.Abs(player.transform.position.y - transform.position.y) <= shootDistance)
            {
                i += Time.deltaTime;
                if (i >= 0.5)
                {
                    //PlaySound._audio.playShoot();//调用音效

                    GameObject bullet = GameObject.Instantiate(bulletPrefab);   //实例化子弹预制体

                    shootCD = 2f;   //射击间隔
                    i = 0;
                    if (Boss.transform.localScale.x > 0)
                    {              //向左射击
                        bullet.transform.position = new Vector3(Boss.transform.position.x - 1, Boss.transform.position.y);
                        bullet.GetComponent<Rigidbody2D>().AddForce(-Vector3.right * Bulletspeed);

                    }
                    else if (Boss.transform.localScale.x < 0)     //向右射击
                    {
                        bullet.transform.position = new Vector3(Boss.transform.position.x + 1, Boss.transform.position.y);
                        bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Bulletspeed);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HP -= damage;
            Instantiate(DamageEffect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);     //销毁子弹
            if (HP <= 0)
            {
                Instantiate(award, transform.position,transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
}
