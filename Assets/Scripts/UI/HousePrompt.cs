using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HousePrompt : MonoBehaviour
{
    public string EnterText, ExitText;


    private BuildingBuilder _builder;

	// Use this for initialization
	private void Start ()
    {
        _builder = GameObject.Find("Building").GetComponent<BuildingBuilder>();
    }
	
	// Update is called once per frame
	private void Update ()
    {
        var house = _builder.CurrentBuilding.GetComponent<House>();
        if (house)
        {
            var text = GetComponent<Text>();
            if (house.InRange)
            {
                
                text.text = house.PlayerInside ? ExitText : EnterText;
            }
            else
            {
                text.text = "";
            }
        }
    }
}
