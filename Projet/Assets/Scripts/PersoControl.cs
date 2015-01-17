using UnityEngine;
using System.Collections;

public class PersoControl : MonoBehaviour {

	private float MoveHorizontal;
	private float MoveVertical;

	public string playerInput = "";
	public GameObject OtherPlayer;  
	public float Vitesse = 10;
	public float Stretch = 5;

	// Use this for initialization
	void Start () {;
	}
	
	// Update is called once per frame
	void Update () {

		MoveHorizontal = Input.GetAxis(playerInput);
		float Distance = OtherPlayer.transform.position.x - this.transform.position.x;


		if (Distance > Stretch)
		{
			if (MoveHorizontal < 0)
			{
				MoveHorizontal /= (Mathf.Abs(Distance) - (Stretch-1));
			}
		}
		else if (Distance < -Stretch)
		{
			if (MoveHorizontal > 0)
			{
				MoveHorizontal /= (Mathf.Abs(Distance) - (Stretch-1));
			}
		}		

		Vector2 movement = new Vector2(MoveHorizontal, 0) * Vitesse;
		rigidbody2D.AddForce (movement);
		//rigidbody2D.velocity = movement;

	}
}
