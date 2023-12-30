using Godot;
using System;

//Player state for when they are on the inventory
public partial class Pinventory : State
{
	public override void HandleInput(InputEvent @event)
    {
        if(@event.IsActionPressed("Inventory"))
        {
            FSM.TransitioToState("Pwalk");
        }
    }
}
