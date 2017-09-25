using UnityEngine;


[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(TopDownController))]
public class PlayerInput : CharacterInput
{
    public bool CheatsEnabled;

    private TopDownController _controller;


    // Use this for initialization
    private void Start()
    {
        _controller = GetComponent<TopDownController>();
    }


    // Update is called once per frame
    private void Update()
    {
        // TODO: Add cooldown
        var inventory = GetComponent<Inventory>();
        if (Input.GetButtonDown("UseItem")) inventory.UseSelectedItem();
        _controller.Input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        for (var i = 0; i < inventory.Items.Length; ++i)
        {
            if (Input.GetButtonDown("ItemSlot" + i))
            {
                inventory.SelectedItem = i;
            }
        }

        if (!CheatsEnabled) return;
        if (Input.GetKeyDown(KeyCode.Alpha1) && Input.GetKey(KeyCode.LeftShift))
        {
            inventory.AddResource("Wood");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && Input.GetKey(KeyCode.LeftShift))
        {
            inventory.AddResource("Stone");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && Input.GetKey(KeyCode.LeftShift))
        {
            inventory.AddResource("Iron");
        }
        if (Input.GetKeyDown(KeyCode.I) && Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<Combateer>().Invincible = !GetComponent<Combateer>().Invincible;
        }
    }
}