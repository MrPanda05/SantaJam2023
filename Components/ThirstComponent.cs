using Godot;
using System;

public partial class ThirstComponent : Node2D
{
    [Export]public float maxThirst = 100f;
    public float thirst;

    [Export] private HealthComponent healthComponent;


    public void GetThirst()
    {
        thirst -= MathF.Round((float)GD.RandRange(5f, 20f), 1);
        thirst = MathF.Round(thirst, 1);
        if(thirst <= 0)
        {
            thirst = 0;
            GD.Print("I am Thirsty");
            healthComponent.TakeDamage();
            return;
        }
    }
    public void Drink(float amout)
    {
        thirst += amout;
        if(thirst > maxThirst)
        {
            ResetThirst();
        }
    }
    public void ResetThirst()
    {
        thirst = maxThirst;
    }
    public void IncreaseMaxThirst(float newMax)
    {
        maxThirst = newMax;
    }
    public override void _Ready()
    {
        ResetThirst();
    }
}
