using Godot;
using System;

public partial class Player : CharacterBody2D
{
    //! Vars
    [Export] private float speed;

    private Vector2 directions, vel;

    //? Custom
    private void GetInputs()
    {
        directions = Input.GetVector("Left", "Right", "Up", "Down").Normalized();
    }

    //* Godots bult In
    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        GetInputs();
        vel = Velocity;
        vel = directions * speed;
        Velocity = vel;
        MoveAndSlide();
    }
}
