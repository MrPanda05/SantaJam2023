using Godot;
using System;

public partial class HungerComponent : Node2D
{
    [Export]public float maxHunger = 100f;
    public float hunger;

    [Export] private HealthComponent healthComponent;


    public void GetHungry()
    {
        hunger -= (float)GD.RandRange(5f, 20f);
        hunger = MathF.Round(hunger, 1);
        if(hunger <= 0)
        {
            hunger = 0;
            GD.Print("I am hungry");
            healthComponent.TakeDamage();
            return;
        }
    }
    public void Eat(float amout)
    {
        hunger += amout;
        if(hunger > maxHunger)
        {
            ResetHunger();
        }
    }
    public void ResetHunger()
    {
        hunger = maxHunger;
    }
    public void IncreaseMaxHunger(float newMax)
    {
        maxHunger = newMax;
    }
    public override void _Ready()
    {
        ResetHunger();
    }

}
