using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {

	public int NbSaved { get; set; }
	public int NbDied { get; set; }

	private HUD Interface;

	//private Fader Fader;

	public int NbDeathMax = 3;

	private bool PlayerDead = false;
	public int FinalCountdown = 3;
	private float DeathTime;

	// Use this for initialization
	void Start () {

		Interface = this.GetComponent<HUD> ();
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (PlayerDead && (Time.time - DeathTime) > FinalCountdown) 
		{
			Application.LoadLevel("Scene");
		}
	}

	public void UpdateDeath()
	{
		Interface.Death++;
		NbDied++;
		if (NbDied > NbDeathMax) 
		{
			GameOver();
		}
	}

	public void UpdateSaved()
	{
		Interface.Saved++;
	}

	public void GameOver()
	{
		if (!PlayerDead) {
						DeathTime = Time.time;
						PlayerDead = true;
						Interface.Over = true;
				}
	}

	public void updateGameStatus ()
	{

	}

}
