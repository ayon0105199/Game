using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreLayers : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("shootable"), LayerMask.NameToLayer("shootable"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
