using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Award : MonoBehaviour {

    public PlayerAttribute PlayerAttribute;
    public int AwardType ;       //1为Coin,2为子弹砖块，3为金币砖块，4为血包，5为钥匙,6为钥匙砖块
    public GameObject DestroyCoinEffect;  //金币消失效果
    public GameObject  bullet, bulletPlus;   //撞击方块所生成的子弹奖励
    public GameObject block_yes, block_no;   //奖励方块
    public bool createAward;                 //是否生成奖励判断
    public Shoot shoot;
    public GameObject Coin,Key;
    
    void Start()
    {
        PlayerAttribute = GameObject.Find("Player").GetComponent<PlayerAttribute>();
        createAward = true;
        shoot = GameObject.Find("Shoot").GetComponent<Shoot>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&AwardType==1)
        {
            PlayerAttribute.AddCoin(100);  //金币
            PlaySound._audio.playCoin();//调用金币音效
            Instantiate(DestroyCoinEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player" && AwardType == 4)
        {
            PlayerAttribute.addBlood(50);
            Destroy(this.gameObject);
            PlaySound._audio.playAward();
        }
        if (collision.gameObject.tag == "Player" && AwardType == 5)
        {
            PlayerAttribute.AddKey(1);
            Destroy(this.gameObject);
            PlaySound._audio.playAward();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //撞击方块生成奖励
        if (collision.gameObject.tag == "Player" && AwardType == 2 && createAward == true)
        {
            createAward = false;
            if (shoot.canShoot == false)
            {
                bullet.SetActive(true);
                block_yes.SetActive(false);
                block_no.SetActive(true);
                PlaySound._audio.playAward();
            }
            else
            { 
               // Instantiate(bulletPlus, transform.position, transform.rotation);
                bulletPlus.SetActive(true);
                block_yes.SetActive(false);
                block_no.SetActive(true);
                PlaySound._audio.playAward();
            }
        }
        if (collision.gameObject.tag == "Player" && AwardType == 3) {
            Coin.SetActive(true);
            block_yes.SetActive(false);
            block_no.SetActive(true);
            PlaySound._audio.playAward();

        }
        if (collision.gameObject.tag == "Player" && AwardType == 6)
        {
            Key.SetActive(true);
            block_yes.SetActive(false);
            block_no.SetActive(true);
            PlaySound._audio.playAward();

        }


    }
}
