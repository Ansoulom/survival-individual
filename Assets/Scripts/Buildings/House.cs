using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour, IBuilding
{
    public bool InRange;

    public bool PlayerInside { get; private set; }
    private Transform _player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void Update ()
    {
        if (InRange)
        {
            if (Input.GetButtonDown("Interact"))
            {
                if (PlayerInside)
                {
                    PlayerInside = false;
                    SetHouseOpen(false);
                }
                else
                {
                    _player.position = transform.position;
                    PlayerInside = true;
                    SetHouseOpen(true);
                }
            }
        }
	}


    private void SetHouseOpen(bool open)
    {
        GetComponent<BoxCollider2D>().enabled = !open;
        transform.Find("Walls").gameObject.SetActive(open);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        InRange = true;
        _player = other.transform;
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        InRange = false;
        _player = null;
    }
}
