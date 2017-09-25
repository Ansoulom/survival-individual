using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("ToggleCrafting"))
        {
            var cw = transform.Find("Crafting Window").gameObject;
            cw.SetActive(!cw.activeSelf);
        }
	}
}
