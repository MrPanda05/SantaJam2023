using Godot;
using System;

public partial class PrintDic : InteractableLogic
{
    public void myInteraction()
    {
        InventoryManager.Instance.playerInventory.PrintAllCountableItems();
        InventoryManager.Instance.playerInventory.PrintAllItems();
        InventoryManager.Instance.playerInventory.PrintAllAnimals();

        

    }
    public override void _Ready()
	{
        GetReady();
		area.OnInteract += myInteraction;
	}
}
