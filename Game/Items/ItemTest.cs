using Godot;
using System;

public partial class ItemTest : Item
{

    public void AddToInventory()
    {
        InventoryManager.Instance.AddItems(itemName);//Add to iventory
        area.OnInteract -= AddToInventory;
        InteractManager.Instance.SetIsInteract(false);
        QueueFree();
    }

    public override void _Ready()
    {
        area = GetNode<InteractableArea>("InteractableArea");
        area.OnInteract += AddToInventory;
        //InteractManager.OnUnRegister += StopTimer;
    }
}
