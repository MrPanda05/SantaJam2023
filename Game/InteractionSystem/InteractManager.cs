using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class InteractManager : Node
{
    public static InteractManager Instance {get; private set;}
    private List<InteractableArea> InteractablesAreas = new List<InteractableArea>();
    private List<float> distanceToPlayer = new List<float>();
    private int index, localIndex;

    private Vector2 playerGlobalPos;
    private CharacterBody2D player;
    private bool canInteract = true, isInteracting = false;


    public static Action OnRegister, OnUnRegister;


    public void Register(InteractableArea  area)
    {
        InteractablesAreas.Add(area);
        OnRegister?.Invoke();
    }

    public void UnRegister(InteractableArea  area)
    {
        InteractablesAreas.Remove(area);
        OnUnRegister?.Invoke();
    }

    public void SetIsInteract(bool isOnInteract)
    {
        isInteracting = isOnInteract;
    }

    public int GetTheClosest()
    {
        localIndex = 0;
        playerGlobalPos = player.GlobalPosition;
        //List<float> pos = new List<float>();
        for (int i = 0; i < InteractablesAreas.Count; i++)
        {
            distanceToPlayer.Add(playerGlobalPos.DistanceTo(InteractablesAreas[i].GlobalPosition));
        }
        localIndex = distanceToPlayer.IndexOf(distanceToPlayer.Min());
        distanceToPlayer.Clear();
        return localIndex;
    }


    public override void _Input(InputEvent @event)
    {  
        if(@event.IsActionPressed("Interact") && canInteract)
        {
            if(isInteracting) return;
            
            isInteracting = true;
            index = GetTheClosest();
            InteractablesAreas[index].OnInteract?.Invoke();
        }
    }
    public override void _Process(double delta)
    {
        canInteract = InteractablesAreas.Count > 0 && !isInteracting;
    }


    public override void _Ready()
    {
        Instance = this;
        player = (CharacterBody2D)GetTree().GetFirstNodeInGroup("Player");
    }
}
