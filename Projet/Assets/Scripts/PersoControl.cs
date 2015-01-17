using UnityEngine;
using System.Collections;

public class PersoControl : MonoBehaviour {

	private float MoveHorizontal;
	private float MoveVertical;

	public string playerInput = "";
	public GameObject OtherPlayer;  
	public float Vitesse = 10;
	private float InitialVitesse;

	// Use this for initialization
	void Start () {
		InitialVitesse = Vitesse;
	}
	
	// Update is called once per frame
	void Update () {

		MoveHorizontal = Input.GetAxis(playerInput);

		float Distance = Mathf.Abs(OtherPlayer.transform.position.x - this.transform.position.x);
		Vitesse = Distance > 6 ? 6 -(Distance-6) : InitialVitesse;

		Vector2 movement = new Vector2(MoveHorizontal, 0) * Vitesse;

		rigidbody2D.AddForce (movement);



		//rigidbody2D.velocity = movement;

	}
}
