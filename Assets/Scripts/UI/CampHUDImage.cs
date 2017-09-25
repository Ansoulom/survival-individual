using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CampHUDImage : MonoBehaviour
{
    private Image _image;
    private BuildingBuilder _builder;

	// Use this for initialization
	private void Start ()
    {
        _image = GetComponent<Image>();
        _builder = GameObject.Find("Building").GetComponent<BuildingBuilder>();
    }
	
	// Update is called once per frame
	private void Update ()
    {
		UpdateImage();
	}


    private void UpdateImage()
    {
        _image.sprite = _builder.CurrentBuilding.GetComponent<SpriteRenderer>().sprite;
    }
}
