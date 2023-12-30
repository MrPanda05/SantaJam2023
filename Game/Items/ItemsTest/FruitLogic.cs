using Godot;
using System;
using System.Threading;

// Demonstration of how the interactable logic should be used
public partial class FruitLogic : InteractableLogic
{
    //note the proprety isSpecial is going to be set only once while creating the interaction logic script
    //This example features how both should react
    //On actual interaction it will not check for special bool
    public void myInteraction()
    {
        if(area.GetIsSpecial())
        {
            area.OnInteract -= myInteraction;
            GD.Print("I am a special fruit");
            DeleteSelf();
        }
        else
        {
            InventoryManager.Instance.AddItem(GetMyNodeParent());
            area.OnInteract -= myInteraction;
            GD.Print("I am not a special fruit");
            DeleteSelf();

        }
    }
	public override void _Ready()
	{
        GetReady();
		area.OnInteract += myInteraction;
	}
}
