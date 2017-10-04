using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundDescriptionsMenuItem : MonoBehaviour
{

	// Use this for initialization
    private void Start ()
    {
		
	}
	
	// Update is called once per frame
    private void Update ()
    {
        if (AudioTextLoader.GetSelectedDescription(GameObject.Find("DescriptionsMenu").GetComponent<SoundDescriptionsMenu>().Clip.Name) == transform.Find("DescriptionField").GetComponent<InputField>().text)
        {
            transform.Find("SelectButton").GetComponent<Button>().interactable = false;
        }
    }


    public void Select()
    {
        AudioTextLoader.SetSelectedDescription(GameObject.Find("DescriptionsMenu").GetComponent<SoundDescriptionsMenu>().Clip.Name, transform.Find("DescriptionField").GetComponent<InputField>().text);
    }
}
