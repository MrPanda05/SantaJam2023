using Godot;
using System;

public partial class FollowState : State
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

        vel = dire.Normalized() * 30;
        currentAnimal.Velocity = vel;
        currentAnimal.MoveAndSlide();
        if(dire.Length() > 250)
        {
            vel = Vector2.Zero;
            currentAnimal.Velocity = vel;
            currentAnimal.MoveAndSlide();
            FSM.TransitioToState("IddleState");
            GD.Print("Entering Iddle state");


        }

    }


}
