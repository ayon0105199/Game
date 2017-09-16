using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamge : MonoBehaviour {

    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;
	// Use this for initialization
	void Start () {
        nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && nextDamage<Time.time)
        {
            playerDeath playerHealth = other.gameObject.GetComponent<playerDeath>();
            playerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(other.transform);
        }
    }

    void pushBack(Transform playerObject)
    {
        Vector2 pushDirection = new Vector2(0, 1);
        pushDirection *= pushBackForce;
        Rigidbody2D myRB = playerObject.gameObject.GetComponent<Rigidbody2D>();
        myRB.velocity = Vector2.zero;
        myRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
