
using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
		public GameObject OriginalFallingObject;
		private GameObject ClonedFallingObject;

		public GameObject BadFallingObject;
		private GameObject ClonedBadObject;

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
			ClonedFallingObject = MonoBehaviour.Instantiate (OriginalFallingObject, this.transform.position, this.transform.rotation) as GameObject;
		}

		public void SpawnBad()
		{
		ClonedBadObject = MonoBehaviour.Instantiate (BadFallingObject, this.transform.position, this.transform.rotation) as GameObject;
		}
}
