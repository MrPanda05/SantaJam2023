using Godot;
using System;

//Player walk state and interacting with basic stuff
public partial class Pwalk : State
{
    private Player player;
    public override void Readys()
    {
        player = (Player)GetParent().GetParent();
    }

    public override void FixUpdate(float delta)
    {
        player.PlayerMove(player.direction);
    }
    public override void HandleInput(InputEvent @event)
    {
        player.direction = Input.GetVector("Left", "Right", "Up", "Down").Normalized();
        
        if(@event.IsActionPressed("Inventory"))
        {
            player.StopPlayer();
            player.UIcomponent.SetVisible();
            FSM.TransitioToState("Pinventory");
        }
        if(@event.IsActionPressed("Pause"))
        {
            player.StopPlayer();
            FSM.TransitioToState("PPause");
        }
        if(@event.IsActionPressed("Interact") && InteractableManager.Instance.isOnArea)
        {
            int index = InteractableManager.Instance.GetTheClosest();
            bool isOnSpecial = InteractableManager.Instance.GetSpecial(index);
            string stateToChange = InteractableManager.Instance.GetStateToChange(index);
            if(isOnSpecial)
            {
                player.StopPlayer();
                InteractableManager.Instance.InteractablesAreas[index].OnInteract?.Invoke();
                FSM.TransitioToState(stateToChange);
                return;
            }
            InteractableManager.Instance.InteractablesAreas[index].OnInteract?.Invoke();
        }
        if(@event.IsActionPressed("Pet") && InteractableManager.Instance.isOnArea)
        {
            int index = InteractableManager.Instance.GetTheClosest();
            InteractableManager.Instance.InteractablesAreas[index].OnPet?.Invoke();
        }
        


    }
}
