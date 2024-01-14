using Godot;
using System;

//Player state for when they are on the inventory
public partial class Pinventory : State
{

    private Player player;
    public override void Readys()
    {
        player = (Player)GetParent().GetParent();
    }
    public override void HandleInput(InputEvent @event)
    {
        if(@event.IsActionPressed("Inventory"))
        {
            //GD.Print(InventoryManager.Instance.GetItemDescription("Fruit2"));
            UIManager.Instance.Inventory.Visible = false;
            FSM.TransitioToState("Pwalk");
        }
    }
}
