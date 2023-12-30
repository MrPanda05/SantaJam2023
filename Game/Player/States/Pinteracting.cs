using Godot;
using System;
//Player state for when the interacting system is in a interacting that last more than two text box
public partial class Pinteracting : State
{
	public override void HandleInput(InputEvent @event)
    {
     
        if(@event.IsActionPressed("Interact"))
        {
            FSM.TransitioToState("Pwalk");
        }
  
    }
}
