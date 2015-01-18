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
		private bool HasStartedFalling = false;
		public AudioSource[] AudioDialogs;
		public AudioSource[] AudioFallings;
		public AudioSource[] AudioCrashes;
		public AudioSource AudioNetStretch;
		public AudioSource AudioNetRebound;
		public AudioSource AudioNetRip;
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

				PlaySound (AudioDialogs);

		}
	
		// Update is called once per frame
		void Update ()
		{
				if ((Time.time - InitTime) > TimeToJump && (Time.time - InitTime) < TimeToFall + 1) {
						this.transform.position += new Vector3 (0, 0.02f, -0.04f); 	
						//this.transform.rotation +=
				}

				if ((Time.time - InitTime) > TimeToFall && !IsDead && !HasStartedFalling) {
						this.rigidbody2D.isKinematic = false;
						HasStartedFalling = true;
						PlaySound (AudioFallings);
				}


				if (HasFallen) {
						this.transform.position += new Vector3 (0, 0, -0.1f);
				}	
				
				if (IsDead) {
						if (this.rigidbody2D.transform.localScale.y > 0) {
								this.rigidbody2D.transform.localScale += new Vector3 (0, -0.1f, 0);
						}
						if (this.rigidbody2D.transform.position.y > -0.48){
							this.rigidbody2D.transform.position += new Vector3 (0, -0.1f, 0);
						}
				}
		}

		void OnCollisionEnter2D (Collision2D col)
		{
				if (isGood) {	
						if (col.gameObject.name == "Floor") {
								this.rigidbody2D.isKinematic = true;
								IsDead = true;
								Engine.UpdateDeath ();
								PlaySound (AudioCrashes);
								StopSound (AudioFallings);
						} else if (col.gameObject.name == "Filet") {
								rigidbody2D.AddForce (new Vector2 (0, 3));
								Engine.UpdateSaved ();
								HasFallen = true;
								PlaySound (AudioNetRebound);
								StopSound (AudioFallings);
						} else if (col.gameObject.name == "Player1" && col.GetType () == typeof(CircleCollider2D)) {
								PlaySound (AudioNetRebound);
								StopSound (AudioFallings);
						} else if (col.gameObject.name == "Player2") {
								PlaySound (AudioNetRebound);
								StopSound (AudioFallings);
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

		void PlaySound (AudioSource Sound)
		{
				Sound.Play ();
		}

		void PlaySound (AudioSource[] Sounds)
		{
				if (Sounds.Length > 0) {
						Sounds [Random.Range (0, Sounds.Length)].Play ();
				}
		}

		void StopSound (AudioSource Sound)
		{
				Sound.Stop ();
		}

		void StopSound (AudioSource[] Sounds)
		{
				if (Sounds.Length > 0) {
						foreach (AudioSource Sound in Sounds) {
								Sound.Stop ();
						}
				}
		}
}
