using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundDescriptionsMenu : MonoBehaviour
{
    public NamedAudioClip Clip;
    public GameObject MenuItemPrefab;
    public GameObject SoundSettingMenu;

	// Use this for initialization
    private void Start ()
    {
        transform.Find("SoundName").GetComponent<Text>().text = Clip.Name;

        var descriptions = AudioTextLoader.GetDescriptions(Clip.Name);
        var items = GameObject.Find("ScrollView").transform.Find("Viewport").transform.Find("Content");
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
        GetComponent<AudioSource>().clip = Clip.Clip;
        GetComponent<AudioSource>().Play();
    }


    public void AddDescription()
    {
        var items = GameObject.Find("ScrollView").transform.Find("Viewport").transform.Find("Content");
        var instance = Instantiate(MenuItemPrefab, items.transform);
    }


    public void GoBack()
    {
        SoundSettingMenu.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
