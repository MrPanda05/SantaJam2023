using Godot;
using System;

public partial class TestHealthComponent : Node2D
{
    [Export] private int maxHealth = 10;

    public int health {get; set;}
    

    public void doDamage()
    {
        if(health <= 0)
        {
            GD.Print("I am dead");
        }
        else
        {
            health--;
            GD.Print("I took damage");
        }
    }
    //Godot functions

    public override void _Ready()
    {
        health = maxHealth;
    }
}
