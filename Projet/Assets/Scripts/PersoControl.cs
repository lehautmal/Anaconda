using UnityEngine;
using System.Collections;

public class PersoControl : MonoBehaviour {

	private float MoveHorizontal;
	private float MoveVertical;

	public string playerInput = "";
	public GameObject OtherPlayer;  
	public float Vitesse = 10;
	public float Stretch = 7;
	private AkAmbient AkTest;

	public Animator Animateur;
	public GameObject Pompier;


	public GameObject Footsteps;
	private float RandomNumber;


	// Use this for initialization
	void Start () {

		Animateur = Pompier.GetComponent<Animator>();
		AkTest = GetComponent<AkAmbient>();

	}
	
	// Update is called once per frame
	void Update () {

		MoveHorizontal = Input.GetAxis(playerInput);
		float Distance = OtherPlayer.transform.position.x - this.transform.position.x;

		if (MoveHorizontal != 0){
			Animateur.SetBool("IsMoving",true);
		}
		else {
			Animateur.SetBool("IsMoving",false);
		}

		if (Distance > Stretch)
		{
			if (MoveHorizontal < 0)
			{
				MoveHorizontal /= (Mathf.Abs(Distance) - (Stretch-1))*15;
			}
		}
		else if (Distance < -Stretch)
		{
			if (MoveHorizontal > 0)
			{
				//Debug.Log ("Joueur2 : " + MoveHorizontal);
				MoveHorizontal /= (Mathf.Abs(Distance) - (Stretch-1))*15;
				Animateur.SetBool("IsMoving",true);
			}
		}	


		Vector2 movement = new Vector2(MoveHorizontal, 0) * Vitesse;
		rigidbody2D.velocity = movement;

	}

	/*public GameObject FootstepsBox()
	{
		Footsteps = MonoBehaviour.Instantiate (FootstepsBox, this.transform.position, this.transform.rotation) as GameObject;
	}*/
}
