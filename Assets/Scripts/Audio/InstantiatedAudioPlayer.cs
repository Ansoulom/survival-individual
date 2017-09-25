using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class InstantiatedAudioPlayer : MonoBehaviour
{
    private bool _started;
    private AudioSource _source;


	// Use this for initialization
	private void Awake ()
    {
        _source = GetComponent<AudioSource>();
    }
	

	// Update is called once per frame
	private void Update ()
    {
        if (_started)
        {
            if (!_source.isPlaying)
            {
                DestroyObject(gameObject);
            }
        }
	}


    private void PlayClip(DescribedAudioClip clip, Vector3 position, float minVolume, float maxVolume,
        float minPitch, float maxPitch)
    {
        transform.position = position;

        _source.clip = clip.Clip;
        _source.volume = Random.Range(minVolume, maxVolume);
        _source.pitch = Random.Range(minPitch, maxPitch);
        _started = true;
        _source.Play();
    }


    public static void PlaySound(DescribedAudioClip clip, Vector3 position, float minVolume, float maxVolume,
        float minPitch, float maxPitch)
    {
        var instance = Instantiate(Resources.Load("Prefabs/AudioPlayer", typeof(GameObject))) as GameObject;
        instance.transform.position = position;
        var audioPlayer = instance.GetComponent<InstantiatedAudioPlayer>();
        audioPlayer.PlayClip(clip, position, minVolume, maxVolume, minPitch, maxPitch);
    }


    public static void PlaySound(AudioClipData clipData, Vector3 position)
    {
        PlaySound(clipData.Clip, position, clipData.MinVolume, clipData.MaxVolume, clipData.MinPitch, clipData.MaxPitch);
    }
}
