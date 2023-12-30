using Godot;
using System;
using System.Collections.Generic;


public partial class InventoryManager : Node
{

    public static InventoryManager Instance {get; private set;}
    public List<ItemBaseClassTest> itemsTest = new List<ItemBaseClassTest>();

    

    public void AddItem(ItemBaseClassTest item)
    {
        itemsTest.Add(item);
    }

    public override void _Ready()
    {
        Instance = this;
    }
}
