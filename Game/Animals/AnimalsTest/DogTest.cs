using Godot;
using System;

public partial class DogTest : BaseAnimal
{
    [Export] public float speed = 50;

    public Action ReachDestination;
    public void GoTo(Vector2 dir, float delta)
    {
        if(GlobalPosition == dir)
        {
            ReachDestination?.Invoke();
        }
        GlobalPosition = GlobalPosition.MoveToward(dir, delta * speed);
        MoveAndSlide();
    }
    public override void Sound()
    {
        GD.Print("wolf");
        
    }

    public override void _Ready()
    {
        ID = GD.Randi();
        GD.Print(ID);
        GD.Print(GetAnimalPathScene());
    }
}
