using UnityEngine;
using System.Collections;

public class SpawnMaster : MonoBehaviour
{
		public GameObject[] Characters;	
		private HUD Interface;
		private const int RowSize = 9;
		private const float RowSizeF = 9f;
		public double TopRowSpawnRate = 1000.0; // en milliseconde
		public double MiddleRowSpawnRate = 1000.0;
		public double BottomRowSpawnRate = 1000.0;
		private double CurrentTopRowSpawnRate; // en milliseconde
		private double CurrentMiddleRowSpawnRate;
		private double CurrentBottomRowSpawnRate;
		public float RandomizerRange = 2.0f;
		public double TopRowSpawnGrowthRate = 2;
		public double MiddleRowSpawnGrowthRate = 2;
		public double BottomRowSpawnGrowthRate = 2;
		public double SpawnGrowthInterval = 10.0;
		private double TopRowNextSpawn = 1000;
		private double MiddleRowNextSpawn = 1000;
		private double BottomRowNextSpawn = 1000;
		private double NextGrowth = 0;

		//public GameObject SpawnerObject;
		//private Spawner SpawnerScript;
		public GameObject[] TopRow = new GameObject[RowSize];
		public GameObject[] MiddleRow = new GameObject[RowSize];
		public GameObject[] BottomRow = new GameObject[RowSize];
		private Spawner[] TopRowSpawners = new Spawner[RowSize];
		private Spawner[] MiddleRowSpawners = new Spawner[RowSize];
		private Spawner[] BottomRowSpawners = new Spawner[RowSize];
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
				/*
		CurrentTopRowSpawnRate = TopRowSpawnRate;
		CurrentMiddleRowSpawnRate = MiddleRowSpawnRate; 
		CurrentBottomRowSpawnRate = BottomRowSpawnRate;

		TopRowNextSpawn = CurrentTopRowSpawnRate;
		MiddleRowNextSpawn = MiddleRowSpawnRate;
		BottomRowNextSpawn = BottomRowSpawnRate;
		NextGrowth = SpawnGrowthInterval;
		*/
		}

		// Update is called once per frame
		void Update ()
		{

				// Incrémente le # de wave <a toutes les TimeBetweenWave secondes.
				if ((Time.time - InitialTime) > (TimeBetweenWave * CurrentWaveNumber)) {
						IncreaseWave ();
				}


				// Vitesse de spawn.
				// Type d'ennemis.
				// Présence d'obstacles.


	
				//SpawnerScript.Spawn ();



				if ((Time.time - InitialTime) > TopRowNextSpawn) {

						float RandomNumber = Random.Range (0f, RowSizeF);
						int Pos = (int)Mathf.Floor (RandomNumber);
						TopRowSpawners [Pos].Spawn ();
						TopRowNextSpawn += TopRowSpawnRate;
						Debug.Log ("Top Row" + Time.time);

						//TopRowNextSpawn += ((Random.Range(0, RandomizerRange)) + CurrentTopRowSpawnRate);


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
						Debug.Log ("Middle Row" + Time.time);
						//TopRowNextSpawn += ((Random.Range(0, RandomizerRange)) + CurrentTopRowSpawnRate);

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
						Debug.Log ("Bottom Row" + Time.time);
						//TopRowNextSpawn += ((Random.Range(0, RandomizerRange)) + CurrentTopRowSpawnRate);
					
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
		
				/*
		if ((Time.time - InitialTime) > MiddleRowNextSpawn) {
			float RandomNumber = Random.Range(0f, RowSizeF);
			int Pos = (int)Mathf.Floor(RandomNumber);
			MiddleRowSpawners[Pos].Spawn();
			MiddleRowNextSpawn += ((Random.Range(0, RandomizerRange)) + CurrentMiddleRowSpawnRate);
			
		}
		if ((Time.time - InitialTime) > BottomRowNextSpawn) {
			float RandomNumber = Random.Range(0f, RowSizeF);
			int Pos = (int)Mathf.Floor(RandomNumber);
			BottomRowSpawners[Pos].Spawn();
			BottomRowNextSpawn += ((Random.Range(0, RandomizerRange)) + CurrentBottomRowSpawnRate);
			
		}
		*/
				/*
		if ((Time.time - InitialTime) > NextGrowth ){
			NextGrowth += SpawnGrowthInterval;
			CurrentTopRowSpawnRate = CurrentTopRowSpawnRate / TopRowSpawnGrowthRate;
			CurrentMiddleRowSpawnRate = CurrentMiddleRowSpawnRate / MiddleRowSpawnGrowthRate;
			CurrentBottomRowSpawnRate = CurrentBottomRowSpawnRate / BottomRowSpawnGrowthRate;
		}
		*/
		}

		public void IncreaseWave ()
		{
				//CurrentWaveNumber = 1;
				CurrentWaveNumber++;
				Debug.Log ("WAVE # " + CurrentWaveNumber);
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
						TopRowNextSpawn = 2;
						MiddleRowNextSpawn = TopRowNextSpawn + 2;
						BottomRowNextSpawn = MiddleRowNextSpawn + 2;
						TopBad = true;
						MidBad = true;
						BotBad = true;
						break;
				}
		
				
				
		}


}
