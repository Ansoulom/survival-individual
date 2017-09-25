using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioClipData))]
public class Pickup : MonoBehaviour
{
    public string Resource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Inventory>().AddResource(Resource);
            InstantiatedAudioPlayer.PlaySound(GetComponent<AudioClipData>(), transform.position);
            DestroyObject(gameObject);
        }
    }
}