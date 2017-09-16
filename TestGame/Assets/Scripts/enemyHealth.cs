using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyHealth : MonoBehaviour {

    public float maxHealth;
    public GameObject deathFX;
    public Slider enemyHealthBar;
    public GameObject dropedItem;
    public bool canDrop;
    public AudioClip enemyDeathSound;

    float currentHealth;
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        enemyHealthBar.maxValue = maxHealth;
        enemyHealthBar.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float Damage)
    {
        enemyHealthBar.gameObject.SetActive(true);
        currentHealth -= Damage;
        enemyHealthBar.value = currentHealth;
        if (currentHealth <= 0) makeDead();
    }

    void makeDead()
    {
        Destroy(gameObject);
        Instantiate(deathFX, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(enemyDeathSound, transform.position);
        if (canDrop) Instantiate(dropedItem, transform.position, transform.rotation);
    }

}
