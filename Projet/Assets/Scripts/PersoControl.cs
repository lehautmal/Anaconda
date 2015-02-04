using UnityEngine;
using System.Collections;

public class PersoControl : MonoBehaviour {

	private float MoveHorizontal;
	private float MoveVertical;

	public string playerInput = "";
	public GameObject OtherPlayer;  
	public float Vitesse = 10;
	public float Stretch = 7;

	public Animator Animateur;
	public GameObject Pompier;

		public bool IsStunned = false;
		public float StunDuration = 1;
		public float StunEndTime;
		public ParticleSystem StunFX;

	// Use this for initialization
	void Start () {
		StunFX.renderer.enabled = false;
		StunFX.Pause ();
		Animateur = Pompier.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		MoveHorizontal = Input.GetAxis(playerInput);
		
		if (IsStunned) {
						MoveHorizontal *= -1;
						Animateur.SetBool("PlayerHit", true);
						if (Time.time > StunEndTime) {
								IsStunned = false;
								StunFX.renderer.enabled = false;
								StunFX.Pause ();
								Animateur.SetBool("PlayerHit", false);
						}			
				}
		
		float Distance = OtherPlayer.transform.position.x - this.transform.position.x;

		if (MoveHorizontal != 0)
			Animateur.SetBool("IsMoving",true);
		else
			Animateur.SetBool("IsMoving",false);

		if (Distance > Stretch)
		{
			if (MoveHorizontal < 0)
			{
				MoveHorizontal /= (Mathf.Abs(Distance) - (Stretch-1))*5;
			}
		}
		else if (Distance < -Stretch)
		{
			if (MoveHorizontal > 0)
			{
				//Debug.Log ("Joueur2 : " + MoveHorizontal);
				MoveHorizontal /= (Mathf.Abs(Distance) - (Stretch-1))*5;
				Animateur.SetBool("IsMoving",true);

			}
		}	


		Vector2 movement = new Vector2(MoveHorizontal, 0) * Vitesse;
		rigidbody2D.velocity = movement;

	}
	
	void OnCollisionEnter2D (Collision2D col)
		{
            if (col.gameObject.tag == "Mur" || col.gameObject.tag == "Player")
              {
                   Stun();
			}
		}

    public void Stun()
    {
        IsStunned = true;
        StunFX.renderer.enabled = true;
        StunFX.Play();
        StunEndTime = Time.time + StunDuration;
        audio.Play();
    }
}
