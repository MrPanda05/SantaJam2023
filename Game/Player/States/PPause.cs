using Godot;
using System;

//Player state for when the player pauses the game
public partial class PPause : State
{
	public override void HandleInput(InputEvent @event)
    {
     
        if(@event.IsActionPressed("Pause"))
        {
            FSM.TransitioToState("Pwalk");
        }
  
    }
}
