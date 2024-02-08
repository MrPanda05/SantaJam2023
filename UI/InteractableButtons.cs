using Godot;
using System;

public partial class InteractableButtons : Control
{
	public Animal animal;
	public Inventory inventory;

	public Node2D AnimalScene, ShopScene, WorkScene;

	[Export] public AudioStreamPlayer healSFX, eatSFX, drinkSFX, failHealSFX, failEatSFX, failDrinkSFX;
	public void OnFeedButtonDown()
	{
		if(inventory.foodAmount > 0)
		{
			animal.hungerComponent.Eat(inventory.foodEatFactor);
			animal.OnStatsChange?.Invoke();
			inventory.RemoveFood();
			GD.Print("Got fed");
			eatSFX.Play();
			return;
		}
			GD.Print("Not enought food");
			failEatSFX?.Play();
	}
	public void OnDrinkButtonDown()
	{
		if(inventory.drinkAmount > 0)
		{
			animal.thirstComponent.Drink(inventory.drinkUpFactor);
			animal.OnStatsChange?.Invoke();
			inventory.RemoveDrink();
			GD.Print("hmmm hydration");
			drinkSFX.Play();
			return;
		}
			GD.Print("Not enought hydration product");
			failDrinkSFX?.Play();
	}
	public void OnHealButtonDown()
	{
		if(inventory.healingItemAmount > 0)
		{
			animal.healthComponent.Heal(inventory.healingFactor);
			animal.OnStatsChange?.Invoke();
			inventory.RemoveHeal();
			GD.Print("hmmm got heal");
			healSFX.Play();
			return;
		}
			GD.Print("Not enought healing items");
			failHealSFX?.Play();
	}

	public void OnWorkButtonDown()
	{
		WorkScene.Visible = true;
		AnimalScene.Visible = false;
		animal.timer.WaitTime = 6f;
	}
	public void OnShopButtonDown()
	{
		
		ShopScene.Visible = true;
		AnimalScene.Visible = false;
		animal.timer.WaitTime = 6f;
	}

    public override void _Ready()
    {
        animal = GetNode<Animal>("../Animal");
		inventory = GetNode<Inventory>("../Inventory");
		AnimalScene = GetNode<Node2D>("../../AnimalScene");
		ShopScene = GetNode<Node2D>("../../Store");
		WorkScene = GetNode<Node2D>("../../Work");

    }


}
