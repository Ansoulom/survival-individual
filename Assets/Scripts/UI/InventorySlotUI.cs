using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    private bool _selected;

    private InventorySlot _slot;
    public Color SelectedColor, UnselectedColor;

    public InventorySlot Slot
    {
        set
        {
            _slot = value;
            UpdateImage();
        }
    }


    public bool Selected
    {
        get { return _selected; }
        set
        {
            if (value != _selected)
            {
                _selected = value;
                UpdateBackground();
            }
        }
    }


    private void Start()
    {
        UpdateBackground();
    }


    // Update is called once per frame
    private void Update()
    {
        UpdateImage();
    }


    private void UpdateBackground()
    {
        var image = transform.Find("Background").GetComponent<Image>();
        image.color = _selected ? SelectedColor : UnselectedColor;
    }


    private void UpdateImage()
    {
        var image = transform.Find("Icon").GetComponent<Image>();
        image.sprite = _slot.Item == null ? null : _slot.Item.Icon;
        image.color = _slot.Item == null ? Color.clear : Color.white;
    }
}