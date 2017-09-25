using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory Inventory;
    public InventorySlotUI[] Slots;


    // Use this for initialization
    private void Start()
    {
        for (var i = 0; i < Slots.Length; ++i)
        {
            Slots[i].Slot = Inventory.Items[i];
            Slots[i].Selected = i == Inventory.SelectedItem;
        }
    }


    private void Update()
    {
        for (var i = 0; i < Slots.Length; ++i)
            Slots[i].Selected = i == Inventory.SelectedItem;
    }
}