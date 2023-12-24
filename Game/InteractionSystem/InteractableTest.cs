using Godot;
using System;

public partial class InteractableTest : CharacterBody2D
{
    private InteractableArea interactableArea;

    private Timer timer;



    public void StopTimer()
    {
        if(timer.TimeLeft > 0)
        {
            GD.Print("Time stop");
            timer.Stop();
        }
        else
        {
            return;
        }
        
        
    }
    private void test()
    {
        GD.Print(InventoryManager.Instance.GetItemCount("ItemTest"));//Read the amount of an item the player has
        GD.Print(ItemTable.Instance.GetItemNameIndex("ItemTest"));// Get the index of the item table so it can be used to access item proprety
        GD.Print(InventoryManager.Instance.GetAnimalByName("AnimalTest").animalName);//Get the animal with the name, can be used to get its proprety
        GD.Print(InventoryManager.Instance.GetAnimalByName("Ana").animalName);
        GD.Print($"my ID IS {InventoryManager.Instance.GetAnimalByName("Ana").ID} and my name is {InventoryManager.Instance.GetAnimalName(InventoryManager.Instance.GetAnimalByName("Ana").ID)}");
        GD.Print($"my ID IS {InventoryManager.Instance.GetAnimalByName("Test").ID}");
        InteractManager.Instance.SetIsInteract(false);
        // foreach (Animal animal in InventoryManager.Instance.playerIventory.animalList)
        // {
        //     GD.Print(animal.animalName);
        // }



        //timer.Start();
    }

    // public void OnTimeTimeout()
    // {
    //     InteractManager.Instance.SetIsInteract(false);
    //     GD.Print("Penis");
    // }

    public override void _Ready()
    {
        interactableArea = GetNode<InteractableArea>("InteractableArea");
        interactableArea.OnInteract += test;
        //InteractManager.OnUnRegister += StopTimer;
        //timer = GetNode<Timer>("Timer");

    }
}
