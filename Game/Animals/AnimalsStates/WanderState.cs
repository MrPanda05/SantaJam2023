using Godot;
using System;

public partial class WanderState : State
{
    public int tries = 0;
    public int maxTries = 3;
    public bool hasReached = false;

    public Vector2 myDestination;


    private Timer timerToReach;
    public Vector2 SetAndGetDestination()
    {
        myDestination = new Vector2(proxy.myMaster.GlobalPosition.X + GD.RandRange(-250, 250), proxy.myMaster.GlobalPosition.Y + GD.RandRange(-250, 250));
        return myDestination;
    }

    public void SetRandonDestination()
    {
        myDestination = new Vector2(proxy.myMaster.GlobalPosition.X + GD.RandRange(-250, 250), proxy.myMaster.GlobalPosition.Y + GD.RandRange(-250, 250));
    }

    public float CalculateTimeToPoint(Vector2 point, float speed)
    {
        //speed = distance / time
        //speed * time = distance
        //time = distance / speed
        return proxy.myMaster.GlobalPosition.DistanceTo(point) / speed;
    }

    public void TryToGoAPoint(float delta)
    {
        if(hasReached) return;
        if(proxy.myMaster.GlobalPosition.IsEqualApprox(myDestination))
        {
            GD.Print("reached");
            proxy.myMaster.Velocity = Vector2.Zero;
            hasReached = true;
            timerToReach.Stop();
            return;
        }
        proxy.myMaster.GlobalPosition = proxy.myMaster.GlobalPosition.MoveToward(myDestination, delta * proxy.myAnimal.speed);
        proxy.myMaster.MoveAndSlide();
    }

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

    public void OnTimerToReachTimeout()
    {
        if(hasReached) return;
        SetRandonDestination();
    }
    public override void Readys()
    {
        timerToReach = GetNode<Timer>("./Timer");
    }
    public override void Enter()
    {
        proxy.myStats.OnStatsDown += StateAnimalChanger; 
    }
    public override void Exit()
    {
        proxy.myStats.OnStatsDown -= StateAnimalChanger; 
    }

    public override void FixUpdate(float delta)
    {
        if(!hasReached)
        {
            TryToGoAPoint(delta);
        }
        else
        {
            SetRandonDestination();
            if(timerToReach.TimeLeft < 0)
            {
                timerToReach.WaitTime = CalculateTimeToPoint(myDestination, proxy.myAnimal.speed);
                timerToReach.Start();
            }
            hasReached = false;
        }
    }


}
