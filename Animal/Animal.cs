using Godot;
using System;

public partial class Animal : Node2D
{

    public HealthComponent healthComponent;
    public HungerComponent hungerComponent;
    public ThirstComponent thirstComponent;

    public Action OnStatsChange;

    private uint temp;

    public Timer timer;

    public void StopTimerOnDeath()
    {
        timer.Stop();
    }
    
    public void OnTimerTimeout()
    {
        temp = GD.Randi() % 3;
        if(temp == 0)
        {
            hungerComponent.GetHungry();
            GD.Print("hmm.. I got hungry");
        }
        else if(temp == 1)
        {
            thirstComponent.GetThirst();
            GD.Print("hmm.. I got Thirsty");
        }
        else
        {
            hungerComponent.GetHungry();
            thirstComponent.GetThirst();
            GD.Print("hmm.. I got hungry and thirsty");
        }
        OnStatsChange?.Invoke();
    }

    public override void _Ready()
    {
        healthComponent = GetNode<HealthComponent>("HealthComponent");
        hungerComponent = GetNode<HungerComponent>("HungerComponent");
        thirstComponent = GetNode<ThirstComponent>("ThirstComponent");
        timer = GetNode<Timer>("Timer");
        healthComponent.OnDeath += StopTimerOnDeath;

    }
}
