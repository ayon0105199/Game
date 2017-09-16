using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour {

	void Start ()
	{
		
	}
	
	void Update ()
	{
		
	}

	public void gotoLevel()
	{
		SceneManager.LoadScene ("Platformer");
	}

	public void gotoInst()
	{
		SceneManager.LoadScene ("InsPage");
	}
}
