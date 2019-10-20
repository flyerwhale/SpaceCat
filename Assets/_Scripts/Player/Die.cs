using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;   //精灵图
    //Alpha的最大最小值  
    public float minAlpha = 0f;
    public float maxAlpha = 1f;  
    public float varifySpeed = 3f;   //变化速度
    public float curAlpha ;             //变量
    public bool i = false;               //是否进行变化判断
    public float timer =0;               //变化时长       
    public PlayerMoving player;
    public PlayerAttribute PlayerAttribute;
    public JumpNumber JumpNumber; 
    

    void Start()    {
        //初始化
        spriteRenderer = GetComponent<SpriteRenderer>();
        curAlpha = 0.5f;
        player = GameObject.Find("Player").GetComponent<PlayerMoving>();
        
        PlayerAttribute = GameObject.Find("Player").GetComponent<PlayerAttribute>();
        JumpNumber = GameObject.Find("JUMP").GetComponent<JumpNumber>();
    }
    void Update()    {
        //变化
        if (i == true) {
            timer += Time.deltaTime;
            
            if (timer < 2)
            {
                player.PlayerCanJump = false;
                curAlpha += Time.deltaTime * varifySpeed;
                if (curAlpha < minAlpha || curAlpha > maxAlpha)
                    varifySpeed *= -1;
                    curAlpha = Mathf.Clamp(curAlpha, minAlpha, maxAlpha);
                JumpNumber.reduce = false;
                player.rigbodyFalse();   //主角刚体休眠方法
                //设置对象的不透明级别       
                if (spriteRenderer != null)
                {
                    Color shadowColor = spriteRenderer.material.color;
                    shadowColor.a = curAlpha;
                    spriteRenderer.material.color = shadowColor;
                }
            }
            //变化结束
            if (timer > 2) {
                curAlpha = maxAlpha;
                if (spriteRenderer != null)
                {
                    Color shadowColor = spriteRenderer.material.color;
                    shadowColor.a = curAlpha;
                    spriteRenderer.material.color = shadowColor;
                }
                player.PlayerCanJump = true;
                timer = 0;   //重置时长
                i = false;   //关闭变化
                player.rigbodyTrue();   //唤醒主角刚体
                JumpNumber.reduce = true;

            }

        }
        
    }

    public void UpdateTransparent()
    {

        i = true;   //开启变化
        
    }

    public void playerDie()
    {

        
        PlayerAttribute.ReduceLife();

        if (PlayerAttribute.life > 0&& PlayerAttribute.RBlood <= 0)
        {


            UpdateTransparent();   //触发死亡后的方法
            player.reload();           //角色重生方法
        }
    }

    


}
