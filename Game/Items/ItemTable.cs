using Godot;
using System;
using System.Collections.Generic;

public partial class ItemTable : Node
{
    //Will hold items so that we can acces its propreties
    public static ItemTable Instance {get; private set;}

    public List<Item> ItemsList = new List<Item>();

    public int GetItemNameIndex(string name)
    {
        for (int i = 0; i < ItemsList.Count; i++)
        {
            if(ItemsList[i].itemName == name)
            {
                return i;
            }
        }
        return -1;
    }


    public override void _Ready()
    {
        Instance = this;
        foreach (Item item in GetChildren())
        {
            ItemsList.Add(item);
        }
    }
}
