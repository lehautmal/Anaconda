using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	const int Height = 25;
	const int Width = 120;
	const int TopMargin = 10;

	Rect NbDeath;
	Rect NbSaved;
	Rect LabelGameOver;
	public int Death { get; set; }
	public int Saved { get; set; }
	public bool Over { get; set; }
	
	void Start()
	{
		NbDeath = new Rect((Screen.width / 2) -40,TopMargin,Width,Height);
		Death = 0;

		NbSaved = new Rect ((Screen.width / 2)-40, 20, Width, Height);
		Saved = 0;

		LabelGameOver = new Rect (Screen.width / 2-40, Screen.height / 2, 120, 25); 
		Over = false;
	}
	
	void OnGUI()
	{
		GUI.Label (NbDeath, "Mort : " + Death);
		GUI.Label (NbSaved, "Sauvetage : " + Saved);

		if (Over) 
		{GUI.Label (LabelGameOver, "GAME OVER");}
	}
}	