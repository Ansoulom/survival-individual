using UnityEngine;
using UnityEngine.UI;

public class CrafteableUI : MonoBehaviour
{
    public Craftable Item;
    public Inventory Inventory { get; set; }
    public Color CanCraftColor, CanNotCraftColor;

    private bool _canCraft;


	// Use this for initialization
	private void Start ()
    {
        UpdateUI();
    }


    private void UpdateUI()
    {
        transform.Find("Name").GetComponent<Text>().text = Item.Name;
        transform.Find("WoodCost").GetComponent<Text>().text = Item.WoodCost.ToString();
        transform.Find("StoneCost").GetComponent<Text>().text = Item.StoneCost.ToString();
        transform.Find("IronCost").GetComponent<Text>().text = Item.IronCost.ToString();
        transform.Find("Icon").GetComponent<Image>().sprite = Item.Icon;

        ChangeEnabled();
    }


    public void CraftItem()
    {
        var upgrade = Item.Craft(Inventory);
        if (upgrade)
        {
            Item = upgrade;
            UpdateUI();
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }
	

	// Update is called once per frame
	private void Update ()
    {
        if (Item.CanCraft(Inventory) != _canCraft)
        {
            ChangeEnabled();
        }
	}


    private void ChangeEnabled()
    {
        _canCraft = Item.CanCraft(Inventory);
        GetComponent<Image>().color = _canCraft ? CanCraftColor : CanNotCraftColor;
        transform.Find("CraftButton").GetComponent<Button>().interactable = _canCraft;
    }
}
