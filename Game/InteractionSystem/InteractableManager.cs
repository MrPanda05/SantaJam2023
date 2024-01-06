using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class InteractableManager : Node
{
	public static InteractableManager Instance {get; private set;}
    public List<InteractableArea> InteractablesAreas = new List<InteractableArea>();
    private List<float> distanceToPlayer = new List<float>();
    private int index, localIndex;
	private Vector2 playerGlobalPos;
    private CharacterBody2D player;
	public bool isOnArea;
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
    /// <summary>
    /// Gets the closest area to the player
    /// </summary>
    /// <returns>index of the closest area to the player</returns>
	 public int GetTheClosest()
    {
        localIndex = 0;
        playerGlobalPos = player.GlobalPosition;
        for (int i = 0; i < InteractablesAreas.Count; i++)
        {
            distanceToPlayer.Add(playerGlobalPos.DistanceTo(InteractablesAreas[i].GlobalPosition));
        }
        localIndex = distanceToPlayer.IndexOf(distanceToPlayer.Min());
        distanceToPlayer.Clear();
        return localIndex;
    }
	public bool GetSpecial(int indexArea)
	{
		return InteractablesAreas[indexArea].GetIsSpecial();
	}
    public string GetStateToChange(int indexArea)
    {
        return InteractablesAreas[indexArea].GetStateString();
    }

    public override void _Process(double delta)
    {
        isOnArea = InteractablesAreas.Count > 0 ? true: false;
    }




    public override void _Ready()
    {
        Instance = this;
        player = (CharacterBody2D)GetTree().GetFirstNodeInGroup("Player");
    }
}
