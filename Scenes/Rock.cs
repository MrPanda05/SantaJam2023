using Godot;
using System;

public partial class Rock : Node2D
{

    public RocksSpawner spawnner;
    public bool canBeMined = false;

    public void OnArea2dMouseEntered()
    {
        canBeMined = true;
        
    }
    public void OnArea2dMouseExited()
    {
        canBeMined = false;
    }
    public override void _Ready()
    {
        spawnner = GetParent() as RocksSpawner;
    }
    public override void _PhysicsProcess(double delta)
    {
        if(Input.IsMouseButtonPressed(MouseButton.Left) && canBeMined)
        {
            GD.Print("Got mined");
            canBeMined = false;
            spawnner.rockCount++;
            spawnner.OnUpdate?.Invoke();
            spawnner.entityCount--;
            QueueFree();
        }
    }
}
