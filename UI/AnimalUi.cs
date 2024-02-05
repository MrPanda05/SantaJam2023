using Godot;
using System;

public partial class AnimalUi : Control
{
	
	public HealthComponent healthComponent;
	public HungerComponent hungerComponent;
	public ThirstComponent thirstComponent;

	public Label healthLabel, thirstLabel, hungerLabel;

	public Animal animal;


	public void UpdataLabels()
	{
		healthLabel.Text = $"Health: {healthComponent.health}";
		hungerLabel.Text = $"Hunger: {hungerComponent.hunger}";
		thirstLabel.Text = $"Thirst: {thirstComponent.thirst}";
	}

    public override void _Ready()
    {
        healthLabel = GetNode<Label>("HealthLabel");
        thirstLabel = GetNode<Label>("ThirstLabel");
        hungerLabel = GetNode<Label>("HungerLabel");
		healthComponent = GetNode<HealthComponent>("../Animal/HealthComponent");
		hungerComponent = GetNode<HungerComponent>("../Animal/HungerComponent");
		thirstComponent = GetNode<ThirstComponent>("../Animal/ThirstComponent");
		animal = GetNode<Animal>("../Animal");
		animal.OnStatsChange += UpdataLabels;
		UpdataLabels();
    }
}
