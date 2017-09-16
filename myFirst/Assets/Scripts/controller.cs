using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {

	private float jumpforce=9000f;
	private float speedMultiplier = 700f;
	private Rigidbody mySphere;
	private float axis;
	private Vector3 groundCheckPosition;
	private bool grounded = false;
	private double velocity;

	void Start ()
	{
		mySphere = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate () 
	{
		mySphere.AddForce (0f, -500f, 0f);
		mySphere.AddForce (0f, 0f, 1000f);

		if (grounded)
		{
			Debug.Log ("Hello");
			if (Input.GetButton ("Jump"))
				mySphere.AddForce (0f, jumpforce, 0f);
		}
		
		axis = Input.GetAxis ("Horizontal") * speedMultiplier;
		Debug.Log (axis);
		mySphere.AddForce (axis, 0f, 0f);




	}

	void Update()
	{
		groundCheckPosition = (transform.position) + new Vector3 (0f, -25f, 0f);
		grounded = Physics.Linecast (transform.position, groundCheckPosition);
	}
}
