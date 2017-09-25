using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBuilder : MonoBehaviour
{
    public GameObject CurrentBuilding;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Build(GameObject building)
    {
        DestroyObject(CurrentBuilding);
        CurrentBuilding = Instantiate(building);
        CurrentBuilding.transform.position = transform.position;
        CurrentBuilding.transform.SetParent(transform);
    }
}
