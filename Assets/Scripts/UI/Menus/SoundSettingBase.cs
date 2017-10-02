using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettingBase : MonoBehaviour
{
    public NamedAudioClip[] SoundClips;
    public GameObject MenuItemPrefab;

	// Use this for initialization
    private void Start()
    {
        foreach (var clip in SoundClips)
        {
            var instance = Instantiate(MenuItemPrefab, transform);
            var menuItem = instance.GetComponent<SoundSettingMenuItem>();
            menuItem.AudioSource = GetComponent<AudioSource>();
            menuItem.Clip = clip;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
