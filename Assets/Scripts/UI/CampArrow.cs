using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampArrow : MonoBehaviour
{
    private BuildingBuilder _builder;
    private Transform _camera;

    // Use this for initialization
    private void Start ()
    {
        _builder = GameObject.Find("Building").GetComponent<BuildingBuilder>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
	
	// Update is called once per frame
	private void Update ()
    {
		transform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, new Vector2(_builder.transform.position.x, _builder.transform.position.y) - new Vector2(_camera.position.x, _camera.position.y + 3f)));
	}
}
