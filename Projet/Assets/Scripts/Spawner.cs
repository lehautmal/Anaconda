
using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
		public GameObject OriginalFallingObject;
        public GameObject ManFallingObject;
        public GameObject GirlFallingObject;
		private GameObject ClonedFallingObject;

		public GameObject BadFallingObject;
		private GameObject ClonedBadObject;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{				
				
		}

		public void Spawn ()
		{
            float RandomNumber = Random.Range(0f, 3f);
            int Pos = (int)Mathf.Floor(RandomNumber);

            switch (Pos)
            {
                case 0:
                    ClonedFallingObject = MonoBehaviour.Instantiate(OriginalFallingObject, this.transform.position, this.transform.rotation) as GameObject;
                    break;
                case 1:
                    ClonedFallingObject = MonoBehaviour.Instantiate(ManFallingObject, this.transform.position, this.transform.rotation) as GameObject;
                    break;
                case 2:
                    ClonedFallingObject = MonoBehaviour.Instantiate(GirlFallingObject, this.transform.position, this.transform.rotation) as GameObject;
                    break;             
            }
			
		}

		public void SpawnBad()
		{
		    ClonedBadObject = MonoBehaviour.Instantiate (BadFallingObject, this.transform.position, this.transform.rotation) as GameObject;
		}
}
