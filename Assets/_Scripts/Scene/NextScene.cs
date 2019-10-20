using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
    public PlayerAttribute PlayerAttribute;
    public GameObject Tips;
    public GameObject player;
    public GameObject camera1, camera2;
    public GameObject level2;

    public int levle;
    public PlayerMoving PlayerMoving;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        PlayerAttribute = GameObject.Find("Player").GetComponent<PlayerAttribute>();
        PlayerMoving = GameObject.Find("Player").GetComponent<PlayerMoving>();
        levle = 1;

    }
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && PlayerAttribute.Key >= 3)
        {
            levle = 2;
            player.transform.position = new Vector3(89f, -8.28f, 0);
            camera1.SetActive(false);
            camera2.SetActive(true);
            level2.SetActive(true);

        }
        if(collision.gameObject.tag == "Player" && PlayerAttribute.Key < 3) {
            Tips.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            Tips.SetActive(false);
        }

    }



}
