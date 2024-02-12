using Godot;
using System;

public partial class Music : Node
{
    public Music Instance {get; private set;}
    public AudioStreamPlayer music;

    public override void _Ready()
    {
        Instance = this;
    }
}
