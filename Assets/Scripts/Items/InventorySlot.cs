public class InventorySlot
{
    public UsableItem Item; // TODO

    public void Use(Inventory user)
    {
        if (Item != null)
        {
            if (Item.Use(user))
            {
                Item = null;
            }
        }
    }
}
