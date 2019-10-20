using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardBullet : MonoBehaviour {

    public Shoot shoot;
    public GameObject DestroyAwardBulletEffect;  //金币消失效果
    public int AwardType;                        //奖励类型   1为射击生成Bullet,2为射击生成BulletPlus
    public static int BulletType;                //子弹奖励类型
    
   // Use this for initialization
    void Start()
    {
        shoot = GameObject.Find("Shoot").GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //射击生成Bullet
        if (collision.gameObject.tag == "Player"&& AwardType == 1)
        {
            shoot.damage = 40;
            shoot.canShoot = true;
            PlaySound._audio.playCoin();//调用金币音效
            Instantiate(DestroyAwardBulletEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
            if (BulletType != 2) { 
            BulletType = 1;
                
            }
        }
        //射击生成BulletPlus
        if (collision.gameObject.tag == "Player" && AwardType == 2)
        {
            shoot.damage = 50;
            shoot.canShoot = true;
            PlaySound._audio.playCoin();//调用金币音效
            Instantiate(DestroyAwardBulletEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
            BulletType = 2;
        }
        if (collision.gameObject.tag == "Player" && AwardType == 3)
        {
            shoot.damage = 70;
            shoot.canShoot = true;
            PlaySound._audio.playCoin();//调用金币音效
            Instantiate(DestroyAwardBulletEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
            BulletType = 3;
        }



    }

}
