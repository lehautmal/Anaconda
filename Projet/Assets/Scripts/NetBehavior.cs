using UnityEngine;
using System.Collections;

public class NetBehavior : MonoBehaviour {

	public GameObject Player1;
	public GameObject Player2;

	// Use this for initialization
	void Start () 
	{
		// Ignore les collisions entre le filet et les pompiers.
		Physics2D.IgnoreLayerCollision(8, 9, true);
	}
	
	// Update is called once per frame
	void Update ()
		{
				float Distance = (Player1.transform.position.x - Player2.transform.position.x);
				float height = Distance < 6 ? -1 + (Distance/6) : 0;
				Vector3 VectorDistance = new Vector3 (Distance / 2, height, 0);
				this.transform.position = Player2.transform.position + VectorDistance;

				Vector3 VectorScale = new Vector3(Distance, this.transform.localScale.y, this.transform.localScale.z);
				this.transform.localScale = VectorScale;

				
				
		}
}
