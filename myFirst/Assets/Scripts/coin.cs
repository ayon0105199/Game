using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour {

	public Text Score;
	public int coins;

	// Use this for initialization
	void Start () {
		coins = 0;
		Score.text = "My Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter()
	{
		coins+=10;
		Score.text= "My Score: " + (coins);
		Destroy (this.gameObject);
	}
}
