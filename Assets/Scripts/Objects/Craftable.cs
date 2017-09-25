using UnityEngine;

public abstract class Craftable : ScriptableObject
{
    public int WoodCost, StoneCost, IronCost;
    public Sprite Icon;
    public string Name;
    public Craftable Upgrade;
    public string Replaces;

    public bool CanCraft(Inventory inv)
    {
        return inv.Contains("Wood", WoodCost) && inv.Contains("Stone", StoneCost) &&
               inv.Contains("Iron", IronCost);
    }


    public Craftable Craft(Inventory inv)
    {
        inv.RemoveResource("Wood", WoodCost);
        inv.RemoveResource("Stone", StoneCost);
        inv.RemoveResource("Iron", IronCost);

        Create(inv);
        return Upgrade;
    }


    protected abstract void Create(Inventory inv);
}