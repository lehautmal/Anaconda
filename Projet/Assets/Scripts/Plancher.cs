using UnityEngine;
using System.Collections;

public class Plancher : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Physics2D.IgnoreLayerCollision (9, 10);
		Physics.IgnoreLayerCollision (9, 10);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
