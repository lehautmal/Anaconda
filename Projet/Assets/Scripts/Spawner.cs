
using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
		public GameObject OriginalFallingObject;
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
		Debug.Log ("SPAWN");
			ClonedFallingObject = MonoBehaviour.Instantiate (OriginalFallingObject, this.transform.position, this.transform.rotation) as GameObject;
		}
}
