using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


	public GameObject test;
	private GameObject test2;


	private float NextSpawn = 0;
	public int SpawnRate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (NextSpawn < Time.time) 
		{
			test2 = MonoBehaviour.Instantiate (test, this.transform.position, this.transform.rotation) as GameObject;
			NextSpawn += SpawnRate;
		}
	}
}
