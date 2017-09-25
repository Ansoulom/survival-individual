using UnityEngine;

public class AudioClipData : MonoBehaviour
{
    [Tooltip("Must be created via Create->Sound->Described Audio Clip")]
    public NamedAudioClip Clip;
    [Tooltip("Volume between 0 and 1")]
    public float MinVolume = 1f;
    [Tooltip("Volume between 0 and 1, at least as high as MinVolume")]
    public float MaxVolume = 1f;
    [Tooltip("1 is the default")]
    public float MinPitch = 1f;
    [Tooltip("1 is the default")]
    public float MaxPitch = 1f;
}
