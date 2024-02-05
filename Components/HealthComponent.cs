using Godot;
using System;

public partial class HealthComponent : Node2D
{
    [Export]public float maxHealth = 100f;
    public float health;

    public Action OnDeath;


    public void TakeDamage()
    {
        health -= 15f;
        if(health <= 0)
        {
            health = 0;
            OnDeath?.Invoke();
            GD.Print("die");
        }
    }
    public void Heal(float amout)
    {
        health += amout;
        if(health > maxHealth)
        {
            ResetHealth();
        }
    }
    public void ResetHealth()
    {
        health = maxHealth;
    }

    public void IncreaseMaxHealth(float newMax)
    {
        maxHealth = newMax;
    }
    public override void _Ready()
    {
        ResetHealth();
    }

}
