using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour {
    public GameObject Menu;
    public  bool i;
    public AudioSource sound, music;//音效、音乐
    public Toggle soundToggle, musicToggle, AudioToggle;//音效，音乐,静音开关
    public Slider soundSlider, musicSlider;//音效、音乐滚动条
    public PlaySound playSound;
    // Use this for initialization
    void Start () {
        i = false;
        playSound= GameObject.Find("Audio Source").GetComponent<PlaySound>();

        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (i == false)
            {
                playSound.playpause();
                Time.timeScale = 0;
                Menu.SetActive(true);
                
                i = true;
                
            }
            else {
                closeMenu();
                
            }




        }
       
	}
    public void closeMenu()
    {
        
        Time.timeScale = 1;
        Menu.SetActive(false);
        
        i = false;
        
    }


    //调整音效大小
    public void soundVolumeChange()
    {
        sound.volume = soundSlider.value;
    }
    //开、关音效
    public void PlaySound()
    {
        if (soundToggle.isOn)
        {
            sound.Play();
            sound.volume = soundSlider.value;
            AudioToggle.isOn = false;
        }
        else
        {
            sound.Stop();
            sound.volume = 0;
            if (musicToggle.isOn == false)
            {
                AudioToggle.isOn = true;
            }
        }
    }
    //调整音乐大小
    public void musicVolumeChange()
    {
        music.volume = musicSlider.value;
    }
    //开、关音乐
    public void PlayMusic()
    {
        if (musicToggle.isOn)
        {
            music.Play();
            music.volume = musicSlider.value;
            AudioToggle.isOn = false;
        }
        else
        {
            music.Pause();
            if (soundToggle.isOn == false)
            {
                AudioToggle.isOn = true;
            }
        }
    }
    //静音
    public void closeAudio()
    {


        if (AudioToggle.isOn)
        {
            music.Pause();
            sound.Stop();
            soundToggle.isOn = false;
            musicToggle.isOn = false;
            sound.volume = 0;
            music.volume = 0;

        }
        else if (AudioToggle.isOn==false&& soundToggle.isOn == false&& musicToggle.isOn == false) { 
        {
            
            //soundToggle.isOn = true;
            soundToggle.isOn = true;
                sound.Play();
            //musicToggle.isOn = true;
            musicToggle.isOn = true;
                music.Play();
            music.volume = musicSlider.value;
            sound.volume = musicSlider.value;
            
        }
        }
    }
    public void Replay() {
        SceneManager.LoadScene(001);
        Time.timeScale = 1;
        AwardBullet.BulletType = 1;
    }
    public void Back()
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene(000);
    }
    public void Exit() {
        Application.Quit();
    }
}
