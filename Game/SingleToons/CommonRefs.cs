using Godot;
using System;

//? Commong reference of nodes so that everynode can get
public partial class CommonRefs : Node
{
    public static CommonRefs Instance {get; private set;}

    public override void _Ready()
    {
        Instance = this;
    }

    public Player GetPlayer()
    {
        return (Player)GetTree().GetFirstNodeInGroup("Player");
    }

    public Vector2 GetPlayerPos(bool global = true)
    {
        if(global)
        {
            return GetPlayer().GlobalPosition;
        }
        else
        {
            return GetPlayer().Position;
            
        }
    }

}
