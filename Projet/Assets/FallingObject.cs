using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	
	}

	void onCollisionEnter2D(Collision2D collider)
	{
		Debug.Log ("TEST");
	}
}
