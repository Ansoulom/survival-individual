using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UIPrompt : MonoBehaviour
{
    public float PromptTime = 2;
    public string Text = "";

    private Timer _activeTimer;
    private bool _active;

	// Use this for initialization
    private void Start ()
    {
        _activeTimer = new Timer(PromptTime);
	}
	
	// Update is called once per frame
	private void Update ()
    {
        if (_active && _activeTimer.Update(Time.deltaTime))
        {
            GetComponent<Text>().text = "";
        }
	}


    public void Activate()
    {
        Activate(Text);
    }

    public void Activate(string text)
    {
        _active = true;
        _activeTimer.Reset();
        GetComponent<Text>().text = text;
    }
}
