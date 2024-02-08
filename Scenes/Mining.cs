using Godot;
using System;

public partial class Mining : Node2D
{
    [Export] public AudioStreamPlayer miningSFX;
    public RocksSpawner spawnner;
    public void PlaySound()
    {
        miningSFX.Play();
    }
    public override void _Ready()
    {
        spawnner = GetNode<RocksSpawner>("RocksSpawner");
        spawnner.OnUpdate += PlaySound;
    }
}
