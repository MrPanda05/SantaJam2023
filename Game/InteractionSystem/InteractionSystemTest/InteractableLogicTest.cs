using Godot;
using System;

public partial class InteractableLogicTest : TestBaseInteractableBase
{

	public void myInteraction()
    {
        if(area.GetIsSpecial())
        {
            area.OnInteract -= myInteraction;
            GD.Print("Is special");
            DeleteSelf();
        }
        else
        {
            area.OnInteract -= myInteraction;
            GD.Print("Is not special");
            DeleteSelf();

        }
    }
	public override void _Ready()
	{
        GetReady();
		area.OnInteract += myInteraction;
	}

	
}
