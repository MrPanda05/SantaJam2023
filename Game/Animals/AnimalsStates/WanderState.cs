using Godot;
using System;

public partial class WanderState : State
{

    private Timer timerState, timerToDirection;

    private Vector2 direction;

    public bool onReach = false;

    public int tries = 0;
    public int maxTries = 3;
    public void StateAnimalChanger()
    {
        if(proxy.myStats.hunger >= 6 && proxy.myStats.thirst >= 6 && proxy.myStats.stamina >= 6 && proxy.myStats.sickness >= 6)
        {
            float temp = GD.Randf();
            if(temp <= 0.5f)
            {
                FSM.TransitioToState("Iddle");
            }
        }
    }
    public void GoTo(Vector2 dir, float delta)
    {
        if(onReach) return;
        if(tries >= maxTries) return;
        if(proxy.myMaster.GlobalPosition == dir)
        {
            GD.Print("Reached");
            proxy.myMaster.Velocity = Vector2.Zero;
            onReach = true;
            return;
        }
        proxy.myMaster.GlobalPosition = proxy.myMaster.GlobalPosition.MoveToward(dir, delta * 30);
        proxy.myMaster.MoveAndSlide();
    }

    public void OnTimeOut()
    {
        StateAnimalChanger();
    }
    public void OnTimerDirectionTimeout()
    {
        if(!onReach) return;
        direction = new Vector2(GD.RandRange(-250, 250), GD.RandRange(-250, 250));
        GD.Print("Going "+ direction);
        onReach = false;
    }

    public override void Readys()
    {
        proxy.myStats.OnStatsDown += StateAnimalChanger;
        timerState = GetNode<Timer>("../Timer"); 
        timerToDirection = GetNode<Timer>("./Timer");
        timerState.OneShot = false;
        timerState.Start();
    }
    public override void Enter()
    {
        direction = new Vector2(proxy.myMaster.GlobalPosition.X + GD.RandRange(-250, 250), proxy.myMaster.GlobalPosition.Y + GD.RandRange(-250, 250));
        GD.Print("Going "+ direction);
    }

    public override void FixUpdate(float delta)
    {
        GoTo(direction, delta);
    }
    public override void Exit()
    {
        timerState.OneShot = true;
    }



}
