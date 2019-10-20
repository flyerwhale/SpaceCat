using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject TouchTheGroundEffect;  //接触地面效果
    public GameObject DamagePlayerEffect;  //角色受伤效果
    public PlayerAttribute PlayerAttribute;
    public int ruduceBlood;
    
    // Use this for initialization
    void Start () {
        PlayerAttribute = GameObject.Find("Player").GetComponent<PlayerAttribute>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        //碰到地面生成碰撞效果
        if (collision.gameObject.tag == "Ground"|| collision.gameObject.tag == "Award")
        {
            Instantiate(TouchTheGroundEffect, transform.position , transform.rotation);
            Destroy(this.gameObject);     //销毁子弹
        }
        if (collision.gameObject.tag == "Player")
        {
            PlayerAttribute.reduceBlood(ruduceBlood);
            Instantiate(DamagePlayerEffect, collision.transform.position, collision.transform.rotation);
            Destroy(this.gameObject);     //销毁子弹
        }




    }
}
