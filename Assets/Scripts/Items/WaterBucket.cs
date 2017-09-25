using UnityEngine;

[CreateAssetMenu(menuName = "Item/HealingItem")]
public class WaterBucket : UsableItem
{
    public UsableItem CreatesItem;


    public override bool Use(Inventory user)
    {
        user.GetComponent<Combateer>().RestoreHealth();
        user.RemoveItem(Name);
        user.AddItem(CreatesItem);
        return false;
    }
}
