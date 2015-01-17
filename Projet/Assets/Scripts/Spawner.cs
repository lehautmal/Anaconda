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
		

}
