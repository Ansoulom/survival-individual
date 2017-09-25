using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ScreenPositioner : MonoBehaviour
{
    public Vector2 WorldPosition;

    private RectTransform _rectTransform;

	// Use this for initialization
    private void Start ()
	{
	    _rectTransform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
    private void Update ()
    {
        var canvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();
        var normalizedHalfWidth = _rectTransform.sizeDelta.x / canvasRect.sizeDelta.x / 2;
        var normalizedHalfHeight = _rectTransform.sizeDelta.y / canvasRect.sizeDelta.y / 2;
        Vector2 viewportPoint = Camera.main.WorldToViewportPoint(WorldPosition);

        if(viewportPoint.x - normalizedHalfWidth < 0) viewportPoint.Set(normalizedHalfWidth, viewportPoint.y);
        if(viewportPoint.x + normalizedHalfWidth > 1) viewportPoint.Set(1 - normalizedHalfWidth, viewportPoint.y);
        if (viewportPoint.y - normalizedHalfHeight < 0) viewportPoint.Set(viewportPoint.x, normalizedHalfHeight);
        if (viewportPoint.y + normalizedHalfHeight > 1) viewportPoint.Set(viewportPoint.x, 1 - normalizedHalfHeight);

        // set MIN and MAX Anchor values(positions) to the same position (ViewportPoint)
        _rectTransform.anchorMin = viewportPoint;
        _rectTransform.anchorMax = viewportPoint;
        //_rectTransform.anchoredPosition = Vector2.zero;
    }
}
