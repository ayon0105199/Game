using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBore : MonoBehaviour {

    public float destroyTime;
    public GameObject deathFX;
    public GameObject drops;
    public AudioClip enemyDeathSound;

    float currentTime;

	// Use this for initialization
	void Start () {
        currentTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") makeDead(collision.gameObject);
    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") makeDead(collision.gameObject);
    }*/
    void makeDead(GameObject other)
    {
        Animator myAnim = other.GetComponentInChildren<Animator>();
        myAnim.SetBool("isCharging", false);
        Destroy(other,destroyTime);
        if (Time.time > currentTime + destroyTime)
        {
            Instantiate(deathFX, other.transform.position, other.transform.rotation);
            Instantiate(drops, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(enemyDeathSound, transform.position);
        }
    }
}
