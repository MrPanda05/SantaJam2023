using Godot;
using System;

public partial class CatStats : AnimalStats
{
    public override void OnTimerTimeout()
    {
        DecreaseHunger();
        OnStatsDown?.Invoke();
    }
    public override void _Ready()
    {
        myAnimal = GetNode<Animal>("..");
        timer = GetNode<Timer>("Timer");
        timer.WaitTime =  15 + GD.Randi() % 10;
        timer.Timeout += OnTimerTimeout;
        timer.Start();
        RandomizeStats();
    }
}
