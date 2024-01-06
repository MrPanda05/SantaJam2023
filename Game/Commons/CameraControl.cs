using Godot;
using System;

public partial class CameraControl : Camera2D
{
	[Export] public CharacterBody2D followPlayer;


    public override void _PhysicsProcess(double delta)
    {
        Position = followPlayer.Position;
    }
}
