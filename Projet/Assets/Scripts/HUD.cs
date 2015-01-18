using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public int Death { get; set; }
	public int Saved { get; set; }
	public bool Over { get; set; }
	public int Level { get; set; }
	
	public TextMesh DeathCount;
	public TextMesh SavedCount;
	public TextMesh WaveCount;

	void Start()
	{
		Death = 0;
		Saved = 0;
		Over = false;
		Level = 1;
	}
	
	void OnGUI()
	{
		DeathCount.text = Death.ToString();
		SavedCount.text = Saved.ToString();
		WaveCount.text = Level.ToString();
		if (Over) {
				}

	}
}	