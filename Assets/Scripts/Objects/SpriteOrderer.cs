using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteOrderer : MonoBehaviour
{
    public bool Dynamic;
    public float PivotOffset;

    // Use this for initialization
    private void Start()
    {
        UpdateSortingOrder();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Dynamic) return;

        UpdateSortingOrder();
    }


    private void UpdateSortingOrder()
    {
        var pos = Mathf.RoundToInt((transform.position.y + PivotOffset * transform.lossyScale.y) * 3);
        //pos /= 3;
        GetComponent<SpriteRenderer>().sortingOrder = pos * -1;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + Vector3.up * PivotOffset * transform.lossyScale.y, 0.1f);
    }
}