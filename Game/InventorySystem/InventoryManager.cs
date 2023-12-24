using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class InventoryManager : Node
{
    public static InventoryManager Instance {get; private set;}

    public PlayerIventory playerIventory;

    //! Items iventory related methods
    public void AddItems(string itemName, int count = 1)
    {
        if(!playerIventory.Items.ContainsKey(itemName))
        {
            playerIventory.Items.Add(itemName, 0);
        }
        playerIventory.Items[itemName] += count;
    }
    public void RemoveItem(string itemName, int count = 1)
    {
        if(!playerIventory.Items.ContainsKey(itemName)) return;

        playerIventory.Items[itemName] -= count;
    }
    public int GetItemCount(string itemName)
    {
        if(!playerIventory.Items.ContainsKey(itemName)) return -1;

        return playerIventory.Items[itemName];
    }

    //! Animals inventory related methods

    /// <summary>
    /// Add a new Animal to the player inventory
    /// </summary>
    /// <param name="animalID">The ID of the animal | the key of the dictionary</param>
    /// <param name="animal">The Animal class Instance | the value of the dictionary</param>
    public void AddAnimal(uint animalID, Animal animal)
    {
        if(playerIventory.Animals.ContainsKey(animalID)) return;
        playerIventory.Animals.Add(animalID, animal);
    }
    /// <summary>
    /// Remove an animal based on its ID
    /// </summary>
    /// <param name="animalID">The ID of the animal to be removed</param>
    public void RemoveAnimal(uint animalID)
    {
        playerIventory.Animals.Remove(animalID);
    }
    /// <summary>
    /// Return the Animal from the dictionary that matches its name
    /// </summary>
    /// <param name="animalName"></param>
    /// <returns>Animal if the animal was found | Null if nothing was found</returns>
    public Animal GetAnimalByName(string animalName)
    {
        foreach(Animal animal in playerIventory.Animals.Values)
        {
            if(animal.animalName == animalName)
            {
                return animal;
            }
        }
        return null;
    }
    public Animal GetAnimalByID(uint animalID)
    {
        return playerIventory.Animals[animalID];
    }
    public string GetAnimalName(uint animalID)
    {
        return playerIventory.Animals[animalID].animalName;
    }
    
    //! Money related methods
    public int GetMoney()
    {
        return playerIventory.money;
    }
    public void SetMoney(int amount)
    {
        playerIventory.money = amount;
    }
    public void AddMoney(int amount)
    {
        playerIventory.money += amount;
    }
    public void RemoveMoney(int amount)
    {
        playerIventory.money -= amount;
        if(playerIventory.money < 0)
        {
            playerIventory.money = 0;
        }
    }
    public override void _Ready()
    {
        Instance = this;
        playerIventory = CommonRefs.Instance.GetPlayer().GetNode<PlayerIventory>("PlayerIventory");
    }

    // public void AddAllAnimalsToList()
    // {
    //     foreach (Animal animal in playerIventory.Animals.Values)
    //     {
    //         if(playerIventory.animalList.Contains(animal))
    //         {
    //             continue;
    //         }
    //         playerIventory.animalList.Add(animal);
    //     }
    // }
}
