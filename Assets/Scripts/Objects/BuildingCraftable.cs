using UnityEngine;

[CreateAssetMenu(menuName = "Craftable/Building")]
public class BuildingCraftable : Craftable
{
    public GameObject Building;

    protected override void Create(Inventory inv)
    {
        var builder = GameObject.Find("Building");
        builder.GetComponent<BuildingBuilder>().Build(Building);
    }
}