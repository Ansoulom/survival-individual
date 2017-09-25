using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieWaveManager : MonoBehaviour
{
    public float TimeToWave = 120f;
    public bool Counting = true;
    public UIPrompt Prompt;


    private Timer _waveTimer;

	// Use this for initialization
	private void Start ()
    {
		_waveTimer = new Timer(TimeToWave);
	}
	
	// Update is called once per frame
	private void Update ()
    {
        if (Counting && _waveTimer.Update(Time.deltaTime))
        {
            transform.Find("Wave 1").gameObject.SetActive(true);
            Counting = false;
            Prompt.Activate();
        }

        if (GetComponentsInChildren<ZombieInput>().Length < 1)
        {
            Prompt.Activate("You survived!");
        }
	}
}
