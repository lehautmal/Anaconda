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
		public bool isGood = true;

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
				if (isGood) {	
						if (col.gameObject.name == "Floor") {
								Engine.UpdateDeath ();
						} else if (col.gameObject.name == "Filet") {
								Engine.UpdateSaved ();
						} else if (col.gameObject.name == "Player1" && col.GetType () == typeof(CircleCollider2D)) {
						} else if (col.gameObject.name == "Player2") {
						}

				} else 
				{
					if (col.gameObject.name == "Floor") {						
					} else if (col.gameObject.name == "Filet") {
						Engine.GameOver();
					} else if (col.gameObject.name == "Player1" && col.GetType () == typeof(CircleCollider2D)) {
					} else if (col.gameObject.name == "Player2") {
					}
			}
		this.collider2D.enabled = false;
		Destroy (this.gameObject, 1);
		HasFallen = true;

		}

	

}
