using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : DeathComponent
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Kill()
    {
        DestroyObject(gameObject);
    }
}
