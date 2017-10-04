using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundSettingBase : MonoBehaviour
{
    public NamedAudioClip[] SoundClips;
    public GameObject MenuItemPrefab;
    public GameObject SoundSettingMenu;

	// Use this for initialization
    private void Start()
    {
        foreach (var clip in SoundClips)
        {
            var instance = Instantiate(MenuItemPrefab, transform);
            var menuItem = instance.GetComponent<SoundSettingMenuItem>();
            menuItem.AudioSource = GetComponent<AudioSource>();
            menuItem.Clip = clip;
            menuItem.SoundSettingMenu = SoundSettingMenu;
        }
	}
	

	// Update is called once per frame
	void Update () {
		
	}


    public void GoBack()
    {
        SceneManager.LoadScene("Start menu");
    }
}
