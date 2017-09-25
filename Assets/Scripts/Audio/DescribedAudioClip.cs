using UnityEngine;

[CreateAssetMenu(menuName = "Sound/Described Audio Clip")]
public class DescribedAudioClip : ScriptableObject
{
    public AudioClip Clip;
    public string Description;
}