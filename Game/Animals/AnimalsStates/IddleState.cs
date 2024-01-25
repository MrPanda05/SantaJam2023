using Godot;
using System;

//! Animal Iddle state
public partial class IddleState : State
{
    public void StateAnimalChanger()
    {
        if(proxy.myStats.hunger >= 6 && proxy.myStats.thirst >= 6 && proxy.myStats.stamina >= 6 && proxy.myStats.sickness >= 6)
        {
            float temp = GD.Randf();
            if(temp <= 0.5f)
            {
                FSM.TransitioToState("Wander");
            }
        }
    }

    public override void Enter()
    {
        proxy.myMaster.Velocity = Vector2.Zero;
        proxy.myStats.OnStatsDown += StateAnimalChanger; 
        //proxy.myStats.DecreaseHunger();
    }
    public override void Exit()
    {
        proxy.myStats.OnStatsDown -= StateAnimalChanger; 
    }


    public override void Update(float delta)
    {
        
    }
}
