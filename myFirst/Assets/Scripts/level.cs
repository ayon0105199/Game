using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour {

	int number;


	// Use this for initialization
	void Start () {
		number=Random.Range(1,4);
		Debug.Log (number);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void isOne()
	{
		if(number==1)
			SceneManager.LoadScene ("win");
		else
			SceneManager.LoadScene ("lose");
	}

	public void isTwo()
	{
		if(number==2)
			SceneManager.LoadScene ("win");
		else
			SceneManager.LoadScene ("lose");
	}

	public void isThree()
	{
		if(number==3)
			SceneManager.LoadScene ("win");
		else
			SceneManager.LoadScene ("lose");
	}

	public void back()
	{
		SceneManager.LoadScene ("startMenu");
	}

}
