using Godot;
using System;

public partial class InteractableButtons : Control
{
	public Animal animal;
	public Inventory inventory;

	public Node2D AnimalScene, ShopScene, WorkScene;
	
	public void OnFeedButtonDown()
	{
		if(inventory.foodAmount > 0)
		{
			animal.hungerComponent.Eat(inventory.foodEatFactor);
			animal.OnStatsChange?.Invoke();
			inventory.RemoveFood();
			GD.Print("Got fed");
			return;
		}
			GD.Print("Not enought food");
	}
	public void OnDrinkButtonDown()
	{
		if(inventory.drinkAmount > 0)
		{
			animal.thirstComponent.Drink(inventory.drinkUpFactor);
			animal.OnStatsChange?.Invoke();
			inventory.RemoveDrink();
			GD.Print("hmmm hydration");
			return;
		}
			GD.Print("Not enought hydration product");
	}
	public void OnHealButtonDown()
	{
		if(inventory.healingItemAmount > 0)
		{
			animal.healthComponent.Heal(inventory.healingFactor);
			animal.OnStatsChange?.Invoke();
			inventory.RemoveHeal();
			GD.Print("hmmm got heal");
			return;
		}
			GD.Print("Not enought healing items");
	}

	public void OnWorkButtonDown()
	{
		WorkScene.Visible = true;
		AnimalScene.Visible = false;
		animal.timer.WaitTime = 6f;
	}
	public void OnShopButtonDown()
	{
		// if(inventory.money <= 0)
		// {
		// 	GD.Print("Poor");
		// 	return;
		// }
		// inventory.RemoveMoney(5);
		// inventory.AddDrinks();
		// inventory.AddFood();
		// inventory.AddHeals();
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
