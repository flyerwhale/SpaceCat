using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    public AudioSource music;
    public AudioClip Run, Shoot, Jump,Coin,Die,Award,Click,Bounce, pause, Water_Drown,AddLife;
    public static PlaySound _audio;
    //奔跑
    public void playRun()
    {
        
        music.PlayOneShot(Run);
    }
    //射击
    public void playShoot()
    {
        music.PlayOneShot(Shoot);
    }
    //跳跃
    public void playJump()
    {
        music.PlayOneShot(Jump);
    }
    //金币
    public void playCoin()
    {
        music.PlayOneShot(Coin);
    }
    //死亡
    public void playDie()
    {
        music.PlayOneShot(Die);
    }
    public void playAward()
    {
        music.PlayOneShot(Award);
    }
    public void playClick()
    {
        music.PlayOneShot(Click);
    }
    public void playBounce()
    {
        music.PlayOneShot(Bounce);
    }
    public void playpause()
    {
        music.PlayOneShot(pause);
    }
    public void playWaterDrown()
    {
        music.PlayOneShot(Water_Drown);
    }
    public void playAddLife()
    {
        music.PlayOneShot(AddLife);
    }



    // Use this for initialization
    void Start()
    {
        _audio = this;
        music = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
