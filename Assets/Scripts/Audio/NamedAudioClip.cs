using UnityEngine;

[CreateAssetMenu(menuName = "Sound/Described Audio Clip")]
public class NamedAudioClip : ScriptableObject
{
    public AudioClip Clip;
    public string Name;
}