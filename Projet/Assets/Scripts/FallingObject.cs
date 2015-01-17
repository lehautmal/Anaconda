using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour
{
		bool HasFallen = false;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (HasFallen) {
			this.transform.position += new Vector3(0,0,-0.01f);
				}	
		}

		void OnCollisionEnter2D (Collision2D col)
		{
				Debug.Log ("OnCollisionEnter was called");
				if (col.gameObject.name == "Floor") {						
						
				} else if (col.gameObject.name == "Cloth") {
						
				} else if (col.gameObject.name == "Player1") {
						
				} else if (col.gameObject.name == "Player2") {
						
				}
				Destroy (this.gameObject, 5);
				HasFallen = true;
		}


}
