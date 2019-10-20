using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour {
    public GameObject HelpPanel,SettingPanel;
    public AudioSource sound, music;//音效、音乐
    public Toggle soundToggle, musicToggle, AudioToggle;//音效，音乐,静音开关
    public Slider soundSlider, musicSlider;//音效、音乐滚动条
    // Use this for initialization
    void Start() {
       

        
    }

    // Update is called once per frame
    void Update() {

    }
    public void openHelpPanel() {
        HelpPanel.SetActive(true);
    }
    public void closeHelpPanel()
    {
        HelpPanel.SetActive(false);
    }
    public void openSettingPanel()
    {
        SettingPanel.SetActive(true);
    }
    public void closeSettingPanel()
    {
        SettingPanel.SetActive(false);
    }
    public void StartGame()
    {
        
        SceneManager.LoadScene(001);
        
    }
    public void CloseGame()
    {
        Application.Quit();
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
        else if (AudioToggle.isOn == false && soundToggle.isOn == false && musicToggle.isOn == false)
        {
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



}
