using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public float speed = 300f;
    public Vector2 direction, vel;

    public void PlayerMove(Vector2 dir)
    {
        vel = Velocity;
        vel = dir * speed;
        Velocity = vel;
        MoveAndSlide();
    }
    public Action OnInventoryEnter;
}
