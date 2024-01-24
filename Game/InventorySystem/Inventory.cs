using Godot;
using System;
using System.Collections.Generic;


public partial class Inventory : Node
{

    //Key: item name 
    //Value: item quantity
    public Dictionary<string, int> countableItems = new Dictionary<string, int>();
    public Dictionary<string, Item> Items = new Dictionary<string, Item>();
    //Items dictionary NEEDS to get the hidden node "HoldItemHidden" otherwise it will break the game

    public Dictionary<uint, Animal> Animals = new Dictionary<uint, Animal>();

    public void UpdateItems()
    {
        foreach (Item item in GetTree().GetNodesInGroup("Item"))
        {
            if(!Items.ContainsKey(item.itemName))
            {
                Items.Add(item.itemName, item);
            }
        }
    }
    public void PrintAllCountableItems()
    {
        foreach (KeyValuePair<string, int> entry in countableItems)
        {
            GD.Print($"{entry.Key} has value of {entry.Value}");
        }
    }
    public void PrintAllItems()
    {
        foreach (KeyValuePair<string, Item> entry in Items)
        {
            GD.Print($"{entry.Key} has value of {entry.Value}");
        }
    }

    public void PrintAllAnimals()
    {
        foreach (KeyValuePair<uint, Animal> entry in Animals)
        {
            GD.Print($"{entry.Key} has value of {entry.Value} with {entry.Value.animalName}");
        }
    }

    public override void _Ready()
    {
        UpdateItems();
    }

}
