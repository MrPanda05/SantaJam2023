using Godot;
using System;

public partial class TestIddleState : State
{
    private CharacterBody2D Player;

    private CharacterBody2D currentAnimal;
    private bool isClose;

    Vector2 dire, vel;

    public override void Readys()
    {
        Player = CommonRefs.Instance.GetPlayer();
        currentAnimal = (CharacterBody2D)GetParent().GetParent();
        GD.Print(currentAnimal.Name);
    }
    public override void FixUpdate(float delta)
    {
        var dire = Player.GlobalPosition - currentAnimal.GlobalPosition;
        if(dire.Length() < 200)
        {
            FSM.TransitioToState("FollowState");
            GD.Print("Entering follow state");
        }

    }
}
