using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAttribute : MonoBehaviour {

    public int Coin;
    public int Key;
    public int Blood;
    public int RBlood;
    public Slider BloodSlider;

    public int life;
    public Sprite[] LifeImage;
    public Die die;
    public GameObject over;

   

    // Use this for initialization
    void Start () {
        Coin = 0;
        Key = 0;
        Blood = RBlood = 100;
        life = 4;
        die = GameObject.Find("Player").GetComponent<Die>();
    }

	// Update is called once per frame
	void Update () {
        BloodSlider.value = (float)RBlood / (float)Blood;
        GameObject.Find("CoinText").GetComponent<Text>().text = Coin.ToString();
        GameObject.Find("KeyText").GetComponent<Text>().text = Key.ToString();
        if (RBlood <= 0&&life>1) {
            die.playerDie();

            RBlood = 100;
        }

        if (life <= 1 && RBlood <= 0) {

            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            over.SetActive(true);
        }

        if (Coin >= 2000 && life <4)
        {
            
            Coin -= 2000;
            PlaySound._audio.playAddLife();//调用音效
            if (life == 3)
            {

                GameObject.Find("Life2").GetComponent<Image>().overrideSprite = LifeImage[0];
                life++;
            }
            if (life == 2)
            {

                GameObject.Find("Life1").GetComponent<Image>().overrideSprite = LifeImage[0];
                life++;
            }
            if (life == 1)
            {
                
                GameObject.Find("Life").GetComponent<Image>().overrideSprite = LifeImage[0];
                life++;
            }

        }

    }

    public void AddCoin(int AddCoin) {

       Coin += AddCoin;
    }
    public void AddKey(int AddKey) {
        Key += AddKey;
    }
    public void reduceBlood(int reduceBlood)
    {

        RBlood -= reduceBlood;
        PlaySound._audio.playDie();  //播放死亡音效
    }
    public void addBlood(int addBlood) {
        if (RBlood <= 50)
        {
            RBlood += addBlood;
        }
        else
            RBlood = 100;
    }

    public void ReduceLife() {
        if (RBlood <= 0) {
        life--;
        
        if (life == 3) {
        
        GameObject.Find("Life2").GetComponent<Image>().overrideSprite = LifeImage[1];
        }
        if (life == 2)
        {
            
            GameObject.Find("Life1").GetComponent<Image>().overrideSprite = LifeImage[1];
        }
        if (life == 1)
        {
            
            GameObject.Find("Life").GetComponent<Image>().overrideSprite = LifeImage[1];
        }
        if (life == 0)
        {

            RBlood = 0;
        }
    }


}
    public void AddLife()
    {



    }

}
