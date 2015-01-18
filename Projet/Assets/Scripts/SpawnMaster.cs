using UnityEngine;
using System.Collections;

public class SpawnMaster : MonoBehaviour {
	private const int RowSize = 9;
	private const float RowSizeF = 9f;

	public double TopRowSpawnRate = 8.0; // en milliseconde
	public double MiddleRowSpawnRate = 1.0; 
	public double BottomRowSpawnRate = 1.0; 
	private double CurrentTopRowSpawnRate; // en milliseconde
	private double CurrentMiddleRowSpawnRate; 
	private double CurrentBottomRowSpawnRate; 

	public float RandomizerRange = 2.0f;
	public double TopRowSpawnGrowthRate = 2;
	public double MiddleRowSpawnGrowthRate = 2;
	public double BottomRowSpawnGrowthRate = 2;
	public double SpawnGrowthInterval = 10.0;

	private double TopRowNextSpawn = 0;
	private double MiddleRowNextSpawn = 0;
	private double BottomRowNextSpawn = 0;
	private double NextGrowth = 0;

	//public GameObject SpawnerObject;
	//private Spawner SpawnerScript;
	public GameObject[] TopRow = new GameObject[RowSize];
	public GameObject[] MiddleRow = new GameObject[RowSize];
	public GameObject[] BottomRow = new GameObject[RowSize];

	private Spawner[] TopRowSpawners = new Spawner[RowSize];
	private Spawner[] MiddleRowSpawners = new Spawner[RowSize];
	private Spawner[] BottomRowSpawners = new Spawner[RowSize];
	// Use this for initialization
	void Start () {
		//SpawnerScript = SpawnerObject.GetComponent(typeof(Spawner)) as Spawner;
		for (int i = 0; i < RowSize; i++) {
			if (TopRow[i] != null){
				TopRowSpawners[i] = TopRow[i].GetComponent(typeof(Spawner)) as Spawner;	
			}
			if (MiddleRow[i] != null){
			MiddleRowSpawners[i] = MiddleRow[i].GetComponent(typeof(Spawner)) as Spawner;
			}
			if (BottomRow[i] != null){
			BottomRowSpawners[i] = BottomRow[i].GetComponent(typeof(Spawner)) as Spawner;
			}
		}

		CurrentTopRowSpawnRate = TopRowSpawnRate;
		CurrentMiddleRowSpawnRate = MiddleRowSpawnRate; 
		CurrentBottomRowSpawnRate = BottomRowSpawnRate;

		TopRowNextSpawn = CurrentTopRowSpawnRate;
		MiddleRowNextSpawn = MiddleRowSpawnRate;
		BottomRowNextSpawn = BottomRowSpawnRate;
		NextGrowth = SpawnGrowthInterval;
			}

	// Update is called once per frame
	void Update () {
		//SpawnerScript.Spawn ();
		//Debug.Log (Time.time);
		if (Time.time > TopRowNextSpawn) {
			float RandomNumber = Random.Range(0f, RowSizeF);
			int Pos = (int)Mathf.Floor(RandomNumber);
			TopRowSpawners[Pos].Spawn();
			TopRowNextSpawn += ((Random.Range(0, RandomizerRange)) + CurrentTopRowSpawnRate);

		}
		if (Time.time > MiddleRowNextSpawn) {
			float RandomNumber = Random.Range(0f, RowSizeF);
			int Pos = (int)Mathf.Floor(RandomNumber);
			MiddleRowSpawners[Pos].Spawn();
			MiddleRowNextSpawn += ((Random.Range(0, RandomizerRange)) + CurrentMiddleRowSpawnRate);
			
		}
		if (Time.time > BottomRowNextSpawn) {
			float RandomNumber = Random.Range(0f, RowSizeF);
			int Pos = (int)Mathf.Floor(RandomNumber);
			BottomRowSpawners[Pos].Spawn();
			BottomRowNextSpawn += ((Random.Range(0, RandomizerRange)) + CurrentBottomRowSpawnRate);
			
		}
		if (Time.time > NextGrowth ){
			NextGrowth += SpawnGrowthInterval;
			CurrentTopRowSpawnRate = CurrentTopRowSpawnRate / TopRowSpawnGrowthRate;
			CurrentMiddleRowSpawnRate = CurrentMiddleRowSpawnRate / MiddleRowSpawnGrowthRate;
			CurrentBottomRowSpawnRate = CurrentBottomRowSpawnRate / BottomRowSpawnGrowthRate;
		}
	}


}
