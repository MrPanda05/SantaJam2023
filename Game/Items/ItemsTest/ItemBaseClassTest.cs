using Godot;
using System;

public partial class ItemBaseClassTest : Node2D
{
    public int count = 0;
    [Export]public float price;
    [Export]public string description;
    [Export]public int ID;
    [Export]public string itemName;

    public void AddSelfToIventory()
    {
        //InventoryManager.AddItem(itemName, this);
    }
}
