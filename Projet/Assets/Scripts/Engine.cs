using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {

	public int NbSaved { get; set; }
	public int NbDied { get; set; }

	private Fader Fader;

	public int NbDeathMax = 1;

	// Use this for initialization
	void Start () {
		Fader = GameObject.Find("Fader").GetComponent<Fader>();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void updateDeath()
	{
		Debug.Log ("DEATH");
		NbDied++;
		if (NbDied > NbDeathMax) 
		{
			Debug.Log ("GAMEOVER");
			//FIN DU JEU
			//System.Threading.Thread.Sleep(1000);
			Application.LoadLevel("Scene");
			//Fader.GotoScene("Scene");
		}
	}

	public void updateGameStatus ()
	{

	}

}
