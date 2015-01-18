using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour
{
		bool HasFallen = false;
		private Material ObjectMaterial;

		private Engine Engine;

		// Use this for initialization
		void Start ()
		{
			Engine = GameObject.Find ("Engine").GetComponent<Engine>();
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
//				Debug.Log ("OnCollisionEnter was called");
//				Debug.Log (col.GetType());
				if (col.gameObject.name == "Floor") {
					renderer.material.color = Color.red;
					Engine.updateDeath();
				} else if (col.gameObject.name == "Filet") {
					renderer.material.color = Color.green;	
				} else if (col.gameObject.name == "Player1" && col.GetType() == typeof(CircleCollider2D)) {
					renderer.material.color = Color.yellow;
				} else if (col.gameObject.name == "Player2") {
					renderer.material.color = Color.yellow;	
				}
		//this.collider2D.enabled = false;
				Destroy (this.gameObject, 1);
				HasFallen = true;
		}


}
