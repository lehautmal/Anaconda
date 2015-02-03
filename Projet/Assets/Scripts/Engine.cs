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

    public AudioClip[] AudioFails;
    public AudioClip[] AudioWins;
    private AudioSource[] Fails;
    private AudioSource[] Wins;

	// Use this for initialization
	void Start () {

		Interface = this.GetComponent<HUD> ();

        Fails = new AudioSource[AudioFails.Length];
        Wins = new AudioSource[AudioWins.Length];
        for (int i = 0; i < AudioFails.Length; i++)
        {
            Fails[i] = gameObject.AddComponent<AudioSource>();
            Fails[i].clip = AudioFails[i];
        }
        Wins = new AudioSource[Wins.Length];
        for (int i = 0; i < AudioWins.Length; i++)
        {
            Wins[i] = gameObject.AddComponent<AudioSource>();
            Wins[i].clip = AudioWins[i];
        }
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
        PlaySound(Fails);
		if (NbDied > NbDeathMax) 
		{
			GameOver();
		}
	}

	public void UpdateSaved()
	{
		Interface.Saved++;
        PlaySound(Wins);
	}

	public void GameOver()
	{
		if (!PlayerDead) {
						DeathTime = Time.time;
						PlayerDead = true;
						Interface.Over = true;
				}
	}

    void PlaySound(AudioSource Sound)
    {
        Sound.Play();
    }

    void PlaySound(AudioSource[] Sounds)
    {
        if (Sounds.Length > 0)
        {
            Sounds[Random.Range(0, Sounds.Length)].Play();
        }
    }

}
