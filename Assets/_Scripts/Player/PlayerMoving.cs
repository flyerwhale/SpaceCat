using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMoving : MonoBehaviour {
    
    public SpriteRenderer pp;
    public Rigidbody2D player;     //人物刚体
    public float moveSpeed = 800;  //移动速度
    public float jumpSpeed = 100;  //跳跃速度
    public Animator ani;           //动画状态机
    public bool isGround = false;  //判断是否在地面
   
    public GameObject TouchTheGroundEffect;  //接触地面效果
    public bool PlayerCanJump=true;

    public bool jump=false;
    

    public EscapeMenu escapeMenu;
    public NextScene NextScene;
    public int jumpNumber;

    //人物在地面上
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground"|| collision.gameObject.tag == "Award")  
        {
            isGround = true;
            jump = false;
            
            //Instantiate(TouchTheGroundEffect, transform.position+0.5f*Vector3.down+0.2f*Vector3.left, transform.rotation);
        }
        //可跳跃次数为2   
        ani.SetBool("Jump", jump);
        ani.SetBool("isGround", isGround);         //将isGround的值写入动画机中的值
        
        if (collision.gameObject.tag == "bounce")
        {

            Vector3 velocity = player.velocity;
            velocity.y = 25;
            player.velocity = velocity;
        }

    }
    //人物离开地面
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
            
        }
        
        ani.SetBool("isGround", isGround);           //将isGround的值写入动画机中的值
        
    }

    void Start()
    {
        pp = gameObject.GetComponent<SpriteRenderer>();
        player = transform.GetComponent<Rigidbody2D>(); //获取刚体
        ani = GetComponent<Animator>();                 //获取动画状态机
        escapeMenu = GameObject.Find("Scripts").GetComponent<EscapeMenu>();
        NextScene = GameObject.Find("NextScene").GetComponent<NextScene>();
        
    }

    void Update()
    {
        jumpNumber = GameObject.Find("JUMP").GetComponent<JumpNumber>().jumpNumber;
        if (escapeMenu.i == false) { 
        //水平方向移动
        float h = Input.GetAxisRaw("Horizontal");
     
        //改变人物朝向
        if (h > 0)//正向
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (h < 0)//反向
        {
            transform.localScale = new Vector3(-1, 1, 1);  
        }

        Vector3 velocity = player.velocity;


        if (Input.GetKeyDown(KeyCode.Space) && jumpNumber > 0&& PlayerCanJump==true)
        {
                jump = true;
            
            PlaySound._audio.playJump();//调用跳跃音效
            velocity.y = jumpSpeed;
            player.velocity = velocity;
                ani.SetBool("Jump", jump);
        }
        ani.SetFloat("horSpeed", Mathf.Abs(player.velocity.x));           //写入动画机中horSpeed的值      
        ani.SetFloat("verSpeed", Mathf.Abs(player.velocity.y));          //写入动画机中verSpeed的值
        player.AddForce(h * Vector3.right * moveSpeed * Time.deltaTime); //移动
    
    }
    }
    //重生到起始位置
    public void reload() {
        if (NextScene.levle == 1) { 
        player.transform.position = new Vector3(-15f, -8.13f, 0);
        }
        if (NextScene.levle == 2)
        {
            player.transform.position = new Vector3(90f, -8.28f, 0);
        }
    }

    //休眠刚体
    public void rigbodyFalse()
    {
        player.Sleep();
        
    }

    //唤醒刚体
    public void rigbodyTrue()
    {
        player.WakeUp();

    }

    public void ChangeColor() {

        pp.color = new Color(0.5f,1,0.5f,255);
    }
    public void ReturnColor()
    {

        pp.color = new Color(1, 1, 1, 255);
    }



}
