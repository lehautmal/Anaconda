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
		Debug.Log (OtherPlayer.transform.position.x - this.transform.position.x);
	}
	
	// Update is called once per frame
	void Update () {

		MoveHorizontal = Input.GetAxis(playerInput);

		float Distance = OtherPlayer.transform.position.x - this.transform.position.x;


		if (Distance > 5)
		{
			MoveHorizontal += Distance - 5;
			Debug.Log (MoveHorizontal);	
		}
		else if (Distance < -5)
		{
			MoveHorizontal += Distance + 5;
			Debug.Log (MoveHorizontal);	
		}		




		Vector2 movement = new Vector2(MoveHorizontal, 0) * Vitesse;

		rigidbody2D.AddForce (movement);



		//rigidbody2D.velocity = movement;

	}
}
