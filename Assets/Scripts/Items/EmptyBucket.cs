using UnityEngine;

[CreateAssetMenu(menuName = "Item/Bucket")]
public class EmptyBucket : UsableItem
{
    public float PickupHitboxRange, PickupHitboxWidth;
    public UsableItem CreatesItem;

    public override bool Use(Inventory user)
    {
        if (NearWater(user.GetComponent<TopDownController>()))
        {
            user.RemoveItem(Name);
            user.AddItem(CreatesItem);
        }
        return false;
    }


    private bool NearWater(TopDownController user)
    {
        var direction = user.Direction;
        var collisions =
            Physics2D.OverlapBoxAll(
                new Vector2(user.transform.position.x, user.transform.position.y) + direction * (PickupHitboxRange / 2),
                new Vector2(PickupHitboxWidth, PickupHitboxRange), Vector2.SignedAngle(Vector2.up, direction));
        foreach (var collision in collisions)
        {
            if (collision.CompareTag("Water"))
            {
                return true;
            }
        }
        return false;
    }
}
