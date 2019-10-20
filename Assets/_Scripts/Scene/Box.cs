using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public float HP;
    public float damage;
    public bool create;
    public GameObject award;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        damage = GameObject.Find("Shoot").GetComponent<Shoot>().damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HP -= damage;
            
            Destroy(collision.gameObject);     //销毁子弹
            if (HP <= 0)
            {
                Destroy(this.gameObject);
                if (create == true) {
                    Instantiate(award, transform.position, transform.rotation);
                }
            }
        }
    }
}
