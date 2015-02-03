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

        private bool TriggerFallingStop = false;
        private bool TriggerFallingStart = false;

        bool IsDead = false;
        bool HasFallen = false;
        bool HasFallenOnHead = false;
        
		public AudioClip[] AudioDialogs;
		public AudioClip[] AudioFallings;
		public AudioClip[] AudioCrashes;
        private AudioSource[] Dialogs;
        private AudioSource[] Fallings;
        private AudioSource[] Crashes;
        public AudioClip AudioNetRebound;
        private AudioSource NetRebound;

		//public AudioSource AudioNetStretch;

		//public AudioSource AudioNetRip;

		// Use this for initialization
		void Start ()
		{			
				Engine = GameObject.Find ("Engine").GetComponent<Engine> ();
				Net = GameObject.FindGameObjectWithTag ("Net").GetComponent<NetBehavior> ();
				this.rigidbody2D.isKinematic = true;
				InitTime = Time.time;	

				Physics2D.IgnoreLayerCollision (11, 11, true);
				Physics.IgnoreLayerCollision (11, 11, true);

                // Conversion des AudioClips en AudioSource.

                Dialogs = new AudioSource[AudioDialogs.Length];
                for (int i = 0; i < AudioDialogs.Length; i++)
                {
                    Dialogs[i] = gameObject.AddComponent<AudioSource>();
                    Dialogs[i].clip = AudioDialogs[i];
                }
                Fallings = new AudioSource[AudioFallings.Length];
                for (int i = 0; i < AudioFallings.Length; i++)
                {
                    Fallings[i] = gameObject.AddComponent<AudioSource>();
                    Fallings[i].clip = AudioFallings[i];
                }
                Crashes = new AudioSource[AudioCrashes.Length];
                for (int i = 0; i < AudioCrashes.Length; i++)
                {
                    Crashes[i] = gameObject.AddComponent<AudioSource>();
                    Crashes[i].clip = AudioCrashes[i];
                }
                NetRebound = gameObject.AddComponent<AudioSource>();
                NetRebound.clip = AudioNetRebound;

				PlaySound (Dialogs);
		}
	
		// Update is called once per frame
		void Update ()
		{
                // Chute du personnage
                if (!IsDead && (Time.time - InitTime) > TimeToJump ) 
                {
                    TriggerFallingStart = true;
                    if (this.rigidbody2D.transform.position.z > -1.66f)         //Position de la trampoline en Z.
                    {
                        this.transform.position += new Vector3(0, 0, -0.04f);
                    }
                    if (this.rigidbody2D.transform.position.z > -1.33f)
                    {
                        this.transform.position += new Vector3(0, 0.02f, 0);
                        this.rigidbody2D.isKinematic = false;
                    }    
                }

                if (TriggerFallingStart && !TriggerFallingStop)
                {
                    PlaySound(Fallings);
                    TriggerFallingStop = true;
                }
                
                // Rebond sur la trampoline
				if (HasFallen) {
						this.transform.position += new Vector3 (0, 0, -0.1f);
                        
				}
                
                // Rebond sur la tête
                if (HasFallenOnHead)
                {
                    this.transform.position += new Vector3(0, 0, -0.033f);
                }

                // Écrapoutillage. 
				if (IsDead) {
						if (this.rigidbody2D.transform.localScale.y > 0) {
								this.rigidbody2D.transform.localScale += new Vector3 (0, -0.1f, 0);
						}
						if (this.rigidbody2D.transform.position.y > -0.20){
							this.rigidbody2D.transform.position += new Vector3 (0, -0.1f, 0);
						}
                        if (this.rigidbody2D.transform.position.y < -0.25)
                        {
                            this.rigidbody2D.transform.position += new Vector3(0, 0.1f, 0);
                        }
				}
		}

		void OnCollisionEnter2D (Collision2D col)
		{
				if (isGood) {	
						if (col.gameObject.layer == 10) {  // 10 = Ground
								this.rigidbody2D.isKinematic = true;
								IsDead = true;
								Engine.UpdateDeath ();
								PlaySound (Crashes);
								StopSound (Fallings);
						} else if (col.gameObject.name == "Filet") {
								rigidbody2D.AddForce (new Vector2 (0, 3));
								Engine.UpdateSaved ();
								HasFallen = true;
								PlaySound (NetRebound);
								StopSound (Fallings);
						} else if (col.gameObject.name == "Player1") {
                                 PersoControl Player1 = col.gameObject.GetComponent<PersoControl>();
                                 Player1.Stun();
                                 rigidbody2D.AddForce(new Vector2(-4, 1));                             
                                 HasFallenOnHead = true;                              
                        }
                        else if (col.gameObject.name == "Player2"){
                                PersoControl Player2 = col.gameObject.GetComponent<PersoControl>();
                                Player2.Stun();
                                rigidbody2D.AddForce(new Vector2(4, 1));
                                HasFallenOnHead = true;                                
						}

				} else {
						if (col.gameObject.layer == 10) {
								this.rigidbody2D.isKinematic = true;
								IsDead = true;
                                PlaySound(Crashes);
						} else if (col.gameObject.name == "Filet") {
								Net.InterCloth.tearFactor = 0.01f;
								Engine.GameOver ();
						} else if (col.gameObject.name == "Player1" && col.GetType () == typeof(CircleCollider2D)) {
                            PersoControl Player1 = col.gameObject.GetComponent<PersoControl>();
                            Player1.Stun();
                            rigidbody2D.AddForce(new Vector2(-4, 1));
                            HasFallenOnHead = true;
						} else if (col.gameObject.name == "Player2") {
                            PersoControl Player2 = col.gameObject.GetComponent<PersoControl>();
                            Player2.Stun();
                            rigidbody2D.AddForce(new Vector2(4, 1));
                            HasFallenOnHead = true;
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
