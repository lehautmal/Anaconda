using UnityEngine;
using System.Collections;

public class SpawnMaster : MonoBehaviour
{
		public GameObject[] Characters;	
		private HUD Interface;
		private const int RowSize = 9;
		private const float RowSizeF = 9f;

        public GameObject[] TopRow = new GameObject[RowSize];
        public GameObject[] MiddleRow = new GameObject[RowSize];
        public GameObject[] BottomRow = new GameObject[RowSize];
        private Spawner[] TopRowSpawners = new Spawner[RowSize];
        private Spawner[] MiddleRowSpawners = new Spawner[RowSize];
        private Spawner[] BottomRowSpawners = new Spawner[RowSize];

		private double TopRowSpawnRate = 1000.0; // en milliseconde
        private double MiddleRowSpawnRate = 1000.0;
        private double BottomRowSpawnRate = 1000.0;
		private double TopRowNextSpawn = 1000;
		private double MiddleRowNextSpawn = 1000;
		private double BottomRowNextSpawn = 1000;

		private float InitialTime;
		private int CurrentWaveNumber = 0;
		public float TimeBetweenWave;
		private bool TopBad = false;
		private bool MidBad = false;
		private bool BotBad = false;

		// Use this for initialization
		void Start ()
		{
				Interface = GameObject.Find ("Engine").GetComponent<HUD> ();
				InitialTime = Time.time;
				//SpawnerScript = SpawnerObject.GetComponent(typeof(Spawner)) as Spawner;
				for (int i = 0; i < RowSize; i++) {
						if (TopRow [i] != null) {
								TopRowSpawners [i] = TopRow [i].GetComponent (typeof(Spawner)) as Spawner;
				TopRowSpawners[i].Characters = this.Characters;
						}
						if (MiddleRow [i] != null) {
								MiddleRowSpawners [i] = MiddleRow [i].GetComponent (typeof(Spawner)) as Spawner;
				MiddleRowSpawners[i].Characters = this.Characters;
						}
						if (BottomRow [i] != null) {
								BottomRowSpawners [i] = BottomRow [i].GetComponent (typeof(Spawner)) as Spawner;
				BottomRowSpawners[i].Characters = this.Characters;
						}
				}
				IncreaseWave ();
		}

		// Update is called once per frame
		void Update ()
		{
				// Incrémente le # de wave <a toutes les TimeBetweenWave secondes.
				if ((Time.time - InitialTime) > (TimeBetweenWave * CurrentWaveNumber) && CurrentWaveNumber < 10) {
						IncreaseWave ();
                        audio.Play();
				}

				if ((Time.time - InitialTime) > TopRowNextSpawn) {

						float RandomNumber = Random.Range (0f, RowSizeF);
						int Pos = (int)Mathf.Floor (RandomNumber);
						TopRowSpawners [Pos].Spawn ();
						TopRowNextSpawn += TopRowSpawnRate;
<<<<<<< HEAD
						Debug.Log ("Top Row" + Time.time);

						//TopRowNextSpawn += ((Random.Range(0, RandomizerRange)) + CurrentTopRowSpawnRate);

=======
						//Debug.Log ("Top Row" + Time.time);
>>>>>>> cd47678c010291ffd146bf6676cfbd53fdb14e12

						if (TopBad) {
								RandomNumber = Random.Range (0f, RowSizeF);
								int Pos2 = (int)Mathf.Floor (RandomNumber);
								while (Pos == Pos2) {
										RandomNumber = Random.Range (0f, RowSizeF);
										Pos2 = (int)Mathf.Floor (RandomNumber);
								}
								TopRowSpawners [Pos2].SpawnBad ();
						}
				}

				if ((Time.time - InitialTime) > MiddleRowNextSpawn) {
						float RandomNumber = Random.Range (0f, RowSizeF);
						int Pos = (int)Mathf.Floor (RandomNumber);
						MiddleRowSpawners [Pos].Spawn ();
						MiddleRowNextSpawn += MiddleRowSpawnRate;
						//Debug.Log ("Middle Row" + Time.time);

						if (MidBad) {
								RandomNumber = Random.Range (0f, RowSizeF);
								int Pos2 = (int)Mathf.Floor (RandomNumber);
								while (Pos == Pos2) {
										RandomNumber = Random.Range (0f, RowSizeF);
										Pos2 = (int)Mathf.Floor (RandomNumber);
								}
								MiddleRowSpawners [Pos2].SpawnBad ();
						}
						
				}

				if ((Time.time - InitialTime) > BottomRowNextSpawn) {
						float RandomNumber = Random.Range (0f, RowSizeF);
						int Pos = (int)Mathf.Floor (RandomNumber);
						BottomRowSpawners [Pos].Spawn ();
						BottomRowNextSpawn += BottomRowSpawnRate;
						//Debug.Log ("Bottom Row" + Time.time);
					
						if (BotBad) {
								RandomNumber = Random.Range (0f, RowSizeF);
								int Pos2 = (int)Mathf.Floor (RandomNumber);
								while (Pos == Pos2) {
										RandomNumber = Random.Range (0f, RowSizeF);
										Pos2 = (int)Mathf.Floor (RandomNumber);
								}
								BottomRowSpawners [Pos2].SpawnBad ();
						}				
				}
		}

        // Balancing du jeu. La difficulté augmente sur 10 waves.
		public void IncreaseWave ()
		{
<<<<<<< HEAD
				//CurrentWaveNumber = 1;
				CurrentWaveNumber++;
				Debug.Log ("WAVE # " + CurrentWaveNumber);
=======
				CurrentWaveNumber++;
				//Debug.Log ("WAVE # " + CurrentWaveNumber);
>>>>>>> cd47678c010291ffd146bf6676cfbd53fdb14e12
				Interface.Level = CurrentWaveNumber;
				
				switch (CurrentWaveNumber) {
				case 1:				
						TopRowSpawnRate = 8;
						TopRowNextSpawn = 2;
						break;
				case 2:
						TopRowSpawnRate = 7;
						TopRowNextSpawn = 26;
						break;
				case 3:
						TopRowSpawnRate = 14;
						MiddleRowSpawnRate = 14;
						MiddleRowNextSpawn = TopRowNextSpawn + 7;
						break;

				case 4:
						TopBad = true;
						break;
				case 5:
						TopRowSpawnRate = 12;
						MiddleRowSpawnRate = 12;
						MidBad = true;
						break;
				case 6:
						TopRowSpawnRate = 10;
						MiddleRowSpawnRate = 10;
						break;
				case 7:
						TopRowSpawnRate = 8;
						MiddleRowSpawnRate = 8;
						break;
				case 8: 
						TopRowSpawnRate = 12;
						MiddleRowSpawnRate = 12;
						BottomRowSpawnRate = 12;
						BottomRowNextSpawn = MiddleRowNextSpawn + 4;
						break;
				case 9: 
						TopRowSpawnRate = 9;
						MiddleRowSpawnRate = 9;
						BottomRowSpawnRate = 9;
						BotBad = true;
						break;

				case 10:
						TopRowSpawnRate = 6;
						MiddleRowSpawnRate = 6;
						BottomRowSpawnRate = 6;
						break;
				}			
		}
}
