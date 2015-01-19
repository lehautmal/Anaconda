
using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
		private GameObject OriginalFallingObject;
		private GameObject ClonedFallingObject;

		public GameObject BadFallingObject;
		private GameObject ClonedBadObject;

	public GameObject [] Characters = null;

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
			OriginalFallingObject = Characters [Random.Range(0, Characters.Length)];
			ClonedFallingObject = MonoBehaviour.Instantiate (OriginalFallingObject, this.transform.position, this.transform.rotation) as GameObject;
			
		}

		public void SpawnBad()
		{
		ClonedBadObject = MonoBehaviour.Instantiate (BadFallingObject, this.transform.position, this.transform.rotation) as GameObject;
		}
}
