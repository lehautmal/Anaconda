using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour
{

		private Material ObjectMaterial;
		private Engine Engine;
		private NetBehavior Net;
		private float InitTime;
		public float TimeToFall;
		public float TimeToJump;
		public bool isGood = true;

		bool IsDead = false;
		bool HasFallen = false;
		// Use this for initialization
		void Start ()
		{			
				Engine = GameObject.Find ("Engine").GetComponent<Engine> ();
				Net = GameObject.FindGameObjectWithTag ("Net").GetComponent<NetBehavior> ();
				this.rigidbody2D.isKinematic = true;
				InitTime = Time.time;	

				Physics2D.IgnoreLayerCollision (11, 11, true);
				Physics.IgnoreLayerCollision (11, 11, true);

				AudioSource test = GetComponent<AudioSource> ();
		test.Play ();

		}
	
		// Update is called once per frame
		void Update ()
		{
				if ((Time.time - InitTime) > TimeToJump && (Time.time - InitTime) < TimeToFall + 0.8) 
				{
					this.transform.position += new Vector3 (0, 0.02f, -0.04f); 	
					//this.transform.rotation +=
				}

				if ((Time.time - InitTime) > TimeToFall && !IsDead) {
					this.rigidbody2D.isKinematic = false;
				}


				if (HasFallen) {
						this.transform.position += new Vector3 (0, 0, -0.1f);
				}	
		}


		void OnCollisionEnter2D (Collision2D col)
		{
				if (isGood) {	
						if (col.gameObject.name == "Floor") {
								this.rigidbody2D.isKinematic = true;
								IsDead = true;
								Engine.UpdateDeath ();	
					} else if (col.gameObject.name == "Filet") {
						rigidbody2D.AddForce(new Vector2(0,3));
								Engine.UpdateSaved ();
								HasFallen = true;
						} else if (col.gameObject.name == "Player1" && col.GetType () == typeof(CircleCollider2D)) {
						} else if (col.gameObject.name == "Player2") {
						}

				} else {
						if (col.gameObject.name == "Floor") {
								this.rigidbody2D.isKinematic = true;
								IsDead = true;
						} else if (col.gameObject.name == "Filet") {
								Net.InterCloth.tearFactor = 0.01f;
								Engine.GameOver ();
						} else if (col.gameObject.name == "Player1" && col.GetType () == typeof(CircleCollider2D)) {
						} else if (col.gameObject.name == "Player2") {
						}
				}
				this.collider2D.enabled = false;
				Destroy (this.gameObject, 3);
				

		}

	

}
