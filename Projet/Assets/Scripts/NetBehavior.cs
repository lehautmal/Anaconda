using UnityEngine;
using System.Collections;

public class NetBehavior : MonoBehaviour
{

		public GameObject Player1;
		public GameObject Player2;
		public float WarnDistance = 7;
		public float MaxDistance = 8;

		public InteractiveCloth Cloth;
		public GameObject 

		// Use this for initialization
		void Start ()
		{
				// Ignore les collisions entre le filet et les pompiers.
				Physics2D.IgnoreLayerCollision (8, 9, true);

		}

		// Update is called once per frame
		void Update ()
		{				
				float Distance = Mathf.Abs (Player1.transform.position.x - Player2.transform.position.x);
				float height = Distance < WarnDistance ? -1 + (Distance / WarnDistance) : 0.3f;
				Vector3 VectorDistance = new Vector3 (Distance / 2, height, 0);
				this.transform.position = Player1.transform.position + VectorDistance;

				Vector3 VectorScale = new Vector3 (Distance, this.transform.localScale.y, this.transform.localScale.z);
				this.transform.localScale = VectorScale;

				if (Distance > MaxDistance) {
						Cloth.tearFactor = 0.5f;
				}
				
		}
}
