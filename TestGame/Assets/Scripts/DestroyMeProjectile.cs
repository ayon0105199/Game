using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeProjectile : MonoBehaviour { 
    public GameObject explosionFX;
    public float destroyTime;

    float currentTime;
	// Use this for initialization
	void Awake () {
        currentTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (currentTime == Time.time + destroyTime) destroyProjectile();

    }

    void destroyProjectile()
    {
        Transform positionOf = gameObject.GetComponentInParent<Transform>();
        Destroy(gameObject);
        Instantiate(explosionFX, positionOf.position, positionOf.rotation);
    }
}
