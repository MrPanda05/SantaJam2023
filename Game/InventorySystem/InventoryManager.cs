using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Manages the inventory of the player
/// </summary>
public partial class InventoryManager : Node
{

    public static InventoryManager Instance {get; private set;}

    public Inventory playerInventory;
    
    //! Items Part
    public void AddNewItem(string itemName)
    {
        if(playerInventory.countableItems.ContainsKey(itemName)) return;
        playerInventory.countableItems.Add(itemName, 0);
        playerInventory.UpdateItems();
        //GD.Print($"Added {itemName} to Inventory");
    }
    public bool IsItemOnInventory(string itemName)
    {
        return playerInventory.countableItems.ContainsKey(itemName);
    }
    public int GetItemCount(string itemName)
    {
        return playerInventory.countableItems[itemName];
    }
    public void IncreamentItemCount(string itemName, int count = 1)
    {
        playerInventory.countableItems[itemName] += count;
        //GD.Print($"Incremented {count} {itemName} and now you have {playerInventory.countableItems[itemName]}");
    }
    public void DecreamentItemCount(string itemName, int count = 1)
    {
        playerInventory.countableItems[itemName] -= count;
        if(playerInventory.countableItems[itemName] < 0)
        {
            playerInventory.countableItems[itemName] = 0;
        }
        //GD.Print($"Decremented {count} to Inventory of key: {itemName} and now value of {playerInventory.countableItems[itemName]}");
    }
    public string GetItemDescription(string itemName)
    {
        if(playerInventory.Items.ContainsKey(itemName))
        {
            return playerInventory.Items[itemName].description;
        }
        return "Item not found";
    }

    public List<string> GetAllItemNames()
    {
        return playerInventory.countableItems.Keys.ToList();
    }

    public Item GetItem(string itemName)
    {
        if(playerInventory.Items.ContainsKey(itemName))
        {
            return playerInventory.Items[itemName];
        }
        return null;
    }

    public string GetItemFilePath(string itemName)
    {
        if(playerInventory.Items.ContainsKey(itemName))
        {
            return playerInventory.Items[itemName].SceneFilePath;
        }
        return null;
    }
    //! Animals Part

    public void AddAnimal(uint ID, BaseAnimal animal)
    {
        if(playerInventory.Animals.ContainsKey(ID)) return;
        playerInventory.Animals.Add(ID, animal);
        //playerInventory.UpdateItems();
    }

    public BaseAnimal GetAnimal(uint ID)
    {
        if(playerInventory.Animals.ContainsKey(ID))
        {
            return playerInventory.Animals[ID];
        }
        return null;
    }
    
    public void RemoveAnimal(uint ID)
    {
        if(!playerInventory.Animals.ContainsKey(ID)) return;
        playerInventory.Animals.Remove(ID);
    }

    public BaseAnimal RemoveAndGetAnimal(uint ID)
    {
        if(!playerInventory.Animals.ContainsKey(ID)) return null;
        var test = playerInventory.Animals[ID];
        playerInventory.Animals.Remove(ID);
        return test;
    }



    public override void _Ready()
    {
        Instance = this;
        playerInventory = GetTree().GetFirstNodeInGroup("Player").GetNode<Inventory>("Inventory");
    }
}
