using Godot;
using System;

public partial class SpriteComponent : AnimatedSprite2D
{
    public override void _Ready()
    {
        Play("Iddle");
    }
}
