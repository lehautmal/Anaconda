using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


	public GameObject test;
	private GameObject test2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		test2 = MonoBehaviour.Instantiate(test, this.transform.position, this.transform.rotation) as GameObject;
		test2 = MonoBehaviour.Instantiate(test, this.transform.position, this.transform.rotation) as GameObject;
		test2 = MonoBehaviour.Instantiate(test, this.transform.position, this.transform.rotation) as GameObject;
		test2 = MonoBehaviour.Instantiate(test, this.transform.position, this.transform.rotation) as GameObject;
		test2 = MonoBehaviour.Instantiate(test, this.transform.position, this.transform.rotation) as GameObject;
		test2 = MonoBehaviour.Instantiate(test, this.transform.position, this.transform.rotation) as GameObject;
		test2 = MonoBehaviour.Instantiate(test, this.transform.position, this.transform.rotation) as GameObject;


	}
}
