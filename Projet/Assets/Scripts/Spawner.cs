<<<<<<< HEAD
using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
		public GameObject FallingObject;
		private GameObject ClonedFallingObject;	

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{				
				
		}

		public void Spawn ()
		{
				ClonedFallingObject = MonoBehaviour.Instantiate (FallingObject, this.transform.position, this.transform.rotation) as GameObject;
		}
		

=======
﻿using UnityEngine;
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
>>>>>>> e9bb84fc4c18470459e95f78ef5c41fd05f5647f
}
