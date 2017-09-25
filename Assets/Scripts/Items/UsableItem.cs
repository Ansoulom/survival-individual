using UnityEngine;

public abstract class UsableItem : ScriptableObject
{
    public string Name;
    public Sprite Icon;

    public abstract bool Use(Inventory user); // Returns true if the item is consumed when used
}