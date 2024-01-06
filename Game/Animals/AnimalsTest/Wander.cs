using Godot;
using System;

public partial class Wander : State
{
    public DogTest Dog;
    public Timer timer;
    public float radium = 300;

    public Vector2 dir;

    public void RestartTimer()
    {
        if(timer.TimeLeft > 0) return;
        timer.Start();
        GD.Print("Time Started");
    }

    public void OnTimerTimeout()
    {
        //Todo change to have negative numbers
        uint test = GD.Randi() % 4;
        if(test == 2)
        {
            timer.Stop();
            FSM.TransitioToState("Iddle");
        }
        dir = new Vector2(GD.Randi() % radium, GD.Randi() % radium);
        GD.Print(dir);
    }
    public override void Readys()
    {
        Dog = GetNode<DogTest>("../..");
        Dog.ReachDestination += RestartTimer;
        timer = GetParent().GetNode<Timer>("Timer");

    }
    public override void Enter()
    {
        timer.Start();
        dir = new Vector2(GD.Randi() % radium, GD.Randi() % radium);
    }

    public override void FixUpdate(float delta)
    {
        Dog.GoTo(dir, delta);
    }

}
