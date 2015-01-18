using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour
{
		bool HasFallen = false;
		private Material ObjectMaterial;
		private Engine Engine;
		private NetBehavior Net;
		private float InitTime;
		public float DelayBeforeJump;

		// Use this for initialization
		void Start ()
		{
				
				Engine = GameObject.Find ("Engine").GetComponent<Engine> ();
				this.rigidbody2D.isKinematic = true;
				InitTime = Time.time;	

				Physics2D.IgnoreLayerCollision (11, 11, true);
				Physics.IgnoreLayerCollision (11, 11, true);

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (HasFallen) {
						this.transform.position += new Vector3 (0, 0, -0.01f);
				}	
				
				if ((Time.time - InitTime) > DelayBeforeJump) {
						this.rigidbody2D.isKinematic = false;	
				}
		}

		void OnCollisionEnter2D (Collision2D col)
		{
				if (col.gameObject.name == "Floor") {
						renderer.material.color = Color.red;
						Engine.UpdateDeath ();
				} else if (col.gameObject.name == "Filet") {
						renderer.material.color = Color.green;
						Engine.UpdateSaved ();
				} else if (col.gameObject.name == "Player1" && col.GetType () == typeof(CircleCollider2D)) {
						renderer.material.color = Color.yellow;
				} else if (col.gameObject.name == "Player2") {
						renderer.material.color = Color.yellow;	
				}
				this.collider2D.enabled = false;
				Destroy (this.gameObject, 1);
				HasFallen = true;
		}

	

}
