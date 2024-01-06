using Godot;
using System;

public partial class AnimalsStatsTest : Node2D
{
    private DogTest Dog;
    private Timer timer;
    public float hunger = 10;
    public float thirst = 10;
    public float sickNess = 10;

    public Action OnStatsDown;


    public void OnTimerTimeout()
    {
        uint i = GD.Randi() % 2;
        if(i == 1)
        {
            GD.Print("Decreasing hunger");
            hunger -= 0.5f;
            thirst -= 0.5f;
            OnStatsDown?.Invoke();
        }
    }


    public override void _Ready()
	{
        Dog = GetNode<DogTest>("..");
        timer = GetNode<Timer>("Timer");
	}

}
