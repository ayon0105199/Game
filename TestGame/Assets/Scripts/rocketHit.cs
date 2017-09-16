﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketHit : MonoBehaviour {

    public float weaponDamage;

    projectileController myPC;

    public GameObject rocketExplosion;

	// Use this for initialization
	void Awake () {
        myPC = GetComponentInParent<projectileController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("shootable"))
        {
            myPC.removeForce();
            Instantiate(rocketExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag=="Enemy")
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("shootable"))
        {
            myPC.removeForce();
            Instantiate(rocketExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }
}
