using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] public float speed = 300f;
    public Vector2 direction;
    private Vector2 vel;

     public void PlayerMove(Vector2 dir)
    {
        vel = Velocity;
        vel = dir * speed;
        Velocity = vel;
        MoveAndSlide();
    }
    public void StopPlayer()
    {
        Velocity = Vector2.Zero;
    }
}
