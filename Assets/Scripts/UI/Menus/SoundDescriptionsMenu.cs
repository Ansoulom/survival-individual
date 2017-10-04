using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundDescriptionsMenu : MonoBehaviour
{
    public NamedAudioClip Clip;
    public GameObject MenuItemPrefab;

	// Use this for initialization
    private void Start ()
    {
        transform.Find("SoundName").GetComponent<Text>().text = Clip.Name;

        var descriptions = AudioTextLoader.GetDescriptions(Clip.Name);
        var items = transform.Find("Content");
        foreach (var description in descriptions)
        {
            var instance = Instantiate(MenuItemPrefab, items.transform);
            instance.transform.Find("DescriptionField").GetComponent<InputField>().text = description;
        }
    }
	

	// Update is called once per frame
    private void Update ()
    {
		
	}


    public void PlaySound()
    {
        
    }


    public void AddDescription()
    {
        
    }
}
