using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickUp : MonoBehaviour {
    public float addHealthAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerDeath addedHealth = other.gameObject.GetComponent<playerDeath>();
            addedHealth.addHealth(addHealthAmount);
            Destroy(gameObject);
        }
    }


}
