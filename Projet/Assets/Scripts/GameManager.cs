using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	//public float worldTime;
	public bool isGamePaused = false;
	
	public Texture2D screenBegin;
	public Texture2D gameOverScreen;
	
	public float initialTimer = 5.0f;
	public float gameOverTimer = 0.0f;
	public bool gameOverState = false;
	public bool finishedBeginningSequence = false;

	public HUD engine;
	public int death;

	//public bool showSwooop = false;
	
	/*public float swooopTimer = 2.0f;
	public float swooopTimerReset = 2.0f;*/
	
	//public float buttonPressTimer = 0.25f;
	//public bool canPressButton = true;
	
	// Use this for initialization
	void Start () 
	{
		//Time.timeScale = worldTime;
		engine = GameObject.Find ("Engine").GetComponent<HUD>();
		death = engine.Death;
	}
	
	void OnGUI()
	{
		//GUI.DrawTexture(Rect(0, 0, Screen.width, Screen.height), screenBegin);
		if (!finishedBeginningSequence)
		{
			GUI.color = new Color(1.0f,1.0f,1.0f,initialTimer);
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), screenBegin, ScaleMode.StretchToFill, true);
		}

		if (gameOverState)
		{
			GUI.color = new Color(1.0f,1.0f,1.0f,gameOverTimer);
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameOverScreen, ScaleMode.StretchToFill, true);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		death = engine.Death;

		if (!finishedBeginningSequence)
		{
			initialTimer -= Time.deltaTime;
		}
		if (initialTimer < 0.0f)
		{
			finishedBeginningSequence = true;
			GUI.color = new Color(1.0f,1.0f,1.0f,1.0f);
		}

		if (death==3)
		{
			gameOverState=true;
		}
		if (gameOverState)
		{
			gameOverTimer += Time.deltaTime;
		}
		if (gameOverTimer > 10.0f)
		{
			gameOverState = false;
			GUI.color = new Color(1.0f,1.0f,1.0f,1.0f);
		}
		
		if (Input.GetKey (KeyCode.Escape))
		{
			Application.Quit();
		}

	}
}