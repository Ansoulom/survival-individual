using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingWindow : MonoBehaviour
{
    public Inventory Inventory;


	// Use this for initialization
    private void Awake() 
    {
        foreach (var child in transform.GetComponentsInChildren<CrafteableUI>())
        {
            child.Inventory = Inventory;
        }
	}
}
