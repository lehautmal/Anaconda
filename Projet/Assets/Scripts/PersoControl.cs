using UnityEngine;
using System.Collections;

public class PersoControl : MonoBehaviour {

	private float MoveHorizontal;
	private float MoveVertical;

	public int vitesse = 10;
	public string playerInput = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		MoveHorizontal = Input.GetAxis(playerInput);

		Vector2 movement = new Vector2(MoveHorizontal, 0) * vitesse;

		rigidbody2D.velocity = movement;

	}
}
