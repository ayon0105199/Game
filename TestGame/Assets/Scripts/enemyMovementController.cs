using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour {

    public float movementSpeed;

    //facing direction
    public GameObject enemy;

    bool canFace = true;
    bool facingRight = false;
    float facingTime = 5f;
    float nextFacingTime = 0f;
    Animator myAnime;

    //charging
    public float chargingTime;

    bool charging = false;
    float startChargeTime;
    Rigidbody2D myRB;

	// Use this for initialization
	void Start () {
        myAnime = GetComponentInChildren<Animator>();
        myRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextFacingTime)
        {
            if (Random.Range(0f, 10f) >= 5) flipFacing();
            nextFacingTime = Time.time + facingTime;
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
     if(other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < enemy.transform.position.x) flipFacing();
            else if (!facingRight && other.transform.position.x > enemy.transform.position.x) flipFacing();
            canFace = false;
            charging = true;
            startChargeTime = Time.time + chargingTime;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(startChargeTime < Time.time)
            {
                if (!facingRight)
                    myRB.AddForce(new Vector2(-1, 0) * movementSpeed);
                else
                    myRB.AddForce(new Vector2(1, 0) * movementSpeed);
                myAnime.SetBool("isCharging", charging);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            charging = false;
            canFace = true;
            myRB.velocity = Vector2.zero;
            myAnime.SetBool("isCharging", false);
            
        }

    }

    void flipFacing()
    {
        if (!canFace) return;
        float facingX = enemy.transform.localScale.x;
        facingX *= -1f;
        enemy.transform.localScale = new Vector3(facingX, enemy.transform.localScale.y, enemy.transform.localScale.z);
        facingRight = !facingRight;
    }
}
