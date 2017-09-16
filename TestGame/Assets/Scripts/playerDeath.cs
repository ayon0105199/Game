using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerDeath : MonoBehaviour {

    public float maxHealth;
    public GameObject deadFX;
    public AudioClip playerHurt;

    float currentHealth;
    playerController myPC;
    Color damagedColor = new Color(0f, 0f, 0f, 0.5f);
    AudioSource playerSound;

    //HUD variables
    public Slider healthBar;
    public Image damageScreen;

    bool damaged = false;
    float smoothing = 5f;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        myPC = GetComponent<playerController>();
        playerSound = GetComponent<AudioSource>();

        //Slider initialisation
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        damaged = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (damaged)
            damageScreen.color = damagedColor;
        else
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothing * Time.deltaTime);
        damaged = false;
	}

    public void addHealth(float health)
    {
        currentHealth += health;
        if (currentHealth >= maxHealth) currentHealth = maxHealth;
        healthBar.value = currentHealth;
    }

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        playerSound.clip = playerHurt;//or use playerSound.playOneShot(playerHurt);
        playerSound.Play();

        healthBar.value = currentHealth;
        damaged = true;
        if (currentHealth <= 0) makeDead();
    }

    public void makeDead()
    {
        Instantiate(deadFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
