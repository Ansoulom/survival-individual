using UnityEngine;
using UnityEngine.UI;

public class SoundSettingMenuItem : MonoBehaviour
{
    public NamedAudioClip Clip;
    public AudioSource AudioSource;

	// Use this for initialization
	private void Start ()
    {
        UpdateUi();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void UpdateUi()
    {
        transform.Find("Name").GetComponent<Text>().text = Clip.Name;
        transform.Find("Current").GetComponent<Text>().text = AudioTextLoader.GetSelectedDescription(Clip.Name);
    }


    public void PlaySound()
    {
        AudioSource.clip = Clip.Clip;
        AudioSource.Play();
    }


    public void GoToDescriptionMenu()
    {
        
    }
}
