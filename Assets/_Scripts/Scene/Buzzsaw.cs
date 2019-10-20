using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buzzsaw : MonoBehaviour {
    public Transform start;
    public Transform end;
    public float speed=100f;
    public Vector3 RotationSpeed = new Vector3(0f, 0f, 300f);
    public int i = 1;
    public float timer;
    public PlayerAttribute playerAttribute;
    // Use this for initialization
    void Start () {
        playerAttribute = GameObject.Find("Player").GetComponent<PlayerAttribute>();

    }
	
	// Update is called once per frame
	void Update () {
        
        timer += Time.deltaTime;

        if (timer <= 4)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, start.position, speed * Time.deltaTime);

        }
        else if (timer >= 4 && timer <= 4.5)
        {

        }
        else if (timer >= 4.5 && timer <= 8.5)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, end.position, speed * Time.deltaTime);
        }
        else if (timer >= 8.5 && timer <= 9)
        {

        }
        else  {
            timer = 0;
        }




        transform.Rotate(2 * RotationSpeed * Time.deltaTime);
      
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            playerAttribute.reduceBlood(100);
        }
    }
}
