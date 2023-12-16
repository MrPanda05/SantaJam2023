using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

//Interactor, the one who press E aka the player
public partial class InteractorManager : Node2D
{
    private List<InteractableArea> InteractablesAreas = new List<InteractableArea>();

    public static InteractorManager InteractorInstance {get; private set;}

    private int index;

    private bool canInteract = true;

    private CharacterBody2D player;

    public override void _Ready()
    {
        InteractorInstance = this;
        player = (CharacterBody2D)GetTree().GetFirstNodeInGroup("Player");
    }

    public void Register(InteractableArea area)
    {
        InteractablesAreas.Add(area);
    }

    public void UnRegister(InteractableArea area)
    {
        InteractablesAreas.Remove(area);
    }

    // Get the closest interactable area
    public int GetCloser()
    {
        int localIndex = 0;
        var playerPos = player.GlobalPosition;
        List<float> pos = new List<float>();
        for (int i = 0; i < InteractablesAreas.Count; i++)
        {
            pos.Add(playerPos.DistanceTo(InteractablesAreas[i].GlobalPosition));
        }
        //GD.Print(pos.Min());
        localIndex = pos.IndexOf(pos.Min());
        return localIndex;
    }
    public override void _Process(double delta)
    {
        if(InteractablesAreas.Count > 0 && !canInteract)
        {
            canInteract = true;
        }
        else
        {
            canInteract = false;
        }
    }


    public override void _Input(InputEvent @event)
    {  
        if(@event.IsActionPressed("Interact") && canInteract)
        {
            //GD.Print("Interacts invoke index: " + index);
            index = GetCloser();
            canInteract = false;
            InteractablesAreas[index].OnInteract?.Invoke();
        }
    }
}
