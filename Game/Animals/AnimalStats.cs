using Godot;
using System;

public partial class AnimalStats : Node2D
{
    protected Animal myAnimal;
    protected FiniteStateMachine FSM = null;
    public Timer timer;
    public int maxHunger = 10;
    public int maxThirst = 10;
    public int maxSickness = 10;
    public int maxStamina = 10;
    public bool isSleep = false;

    public float hunger;
    public float thirst;
    public float sickness;
    public float stamina;

    public float decresseRate = 0.4f;



    public Action OnStatsDown, OnRandomize;


    public void DecreaseAllStats()
    {
        if(ShouldChange())
        {
            hunger -= decresseRate;
            thirst -= decresseRate;
            sickness -= decresseRate;
            sickness -= decresseRate;
        }
    }
    public virtual void Sleep()
    {

    }
    public virtual void WakeUp()
    {

    }
    public void RandomizeStats()
    {
        float temp = GD.RandRange(6, 10);
        hunger = temp;
        temp = GD.RandRange(6, 10);
        thirst = temp;
        temp = GD.RandRange(6, 10);
        sickness = temp;
        temp = GD.RandRange(6, 10);
        stamina = temp;
        OnRandomize?.Invoke();

    }
    //Logic to see if an animal should have an stats changed
    private bool ShouldChange(float percent = 0.5f)
    {
        float newRandom = GD.Randf();

        if(newRandom <= percent)
        {
            return true;
        }
        return false;
    }



    public virtual void OnTimerTimeout()
    {
        // uint i = GD.Randi() % 2;
        // if(i == 1)
        // {
        //     GD.Print("Decreasing hunger");
        //     hunger -= 0.5f;
        //     thirst -= 0.5f;
        //     OnStatsDown?.Invoke();
        // }
    }
    
}
