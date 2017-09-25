using UnityEngine;

[CreateAssetMenu(menuName = "Item/MeleeWeapon")]
public class MeleeWeapon : UsableItem
{
    public int Damage = 1;


    public override bool Use(Inventory user)
    {
        user.GetComponent<Combateer>().Attack(Damage);
        return false;
    }
}