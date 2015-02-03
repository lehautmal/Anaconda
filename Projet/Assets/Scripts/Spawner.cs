
using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
<<<<<<< HEAD
		private GameObject OriginalFallingObject;
=======
		public GameObject OriginalFallingObject;
        public GameObject ManFallingObject;
        public GameObject GirlFallingObject;
>>>>>>> cd47678c010291ffd146bf6676cfbd53fdb14e12
		private GameObject ClonedFallingObject;

		public GameObject BadFallingObject;
		private GameObject ClonedBadObject;

	public GameObject [] Characters = null;

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
<<<<<<< HEAD
			OriginalFallingObject = Characters [Random.Range(0, Characters.Length)];
			ClonedFallingObject = MonoBehaviour.Instantiate (OriginalFallingObject, this.transform.position, this.transform.rotation) as GameObject;
=======
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
>>>>>>> cd47678c010291ffd146bf6676cfbd53fdb14e12
			
		}

		public void SpawnBad()
		{
		    ClonedBadObject = MonoBehaviour.Instantiate (BadFallingObject, this.transform.position, this.transform.rotation) as GameObject;
		}
}
