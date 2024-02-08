using Godot;
using System;

public partial class IndieStoreItems : Panel
{
	public Label nameLabel, priceLabel, countLabel;
	[Export] public string itemName;

	[Export] public int price;

	[Export] private int ID;

	public uint count = 0;
	private Inventory inventory;
	
	public AudioStreamPlayer buySFX;
	
	// 0 - food
	// 1 - drink
	// 2 - health
	// 3 - food factor
	// 4 - drink factor
	// 5 - health factor
	public void UpdateCountItem()
	{
		switch (ID)
		{
			case 0:
			count = inventory.foodAmount;
			countLabel.Text = $"{count}";
			break;
			case 1:
			count = inventory.drinkAmount;
			countLabel.Text = $"{count}";
			break;
			case 2:
			count = inventory.healingItemAmount;
			countLabel.Text = $"{count}";
			break;
		}
	}
    public override void _Ready()
    {
		buySFX = GetNode<AudioStreamPlayer>("../../BuyingSFX");
		nameLabel = GetNode<Label>("Name");
		priceLabel = GetNode<Label>("Price");
		countLabel = GetNode<Label>("Count");
        nameLabel.Text = itemName;
		priceLabel.Text = $"M$:{price}";
		inventory = GetNode<Inventory>("../../../../AnimalScene/Inventory");
		inventory.OnInventoryUpdate += UpdateCountItem;
		switch (ID)
		{
			case 0:
			count = inventory.foodAmount;
			countLabel.Text = $"{count}";
			break;
			case 1:
			count = inventory.drinkAmount;
			countLabel.Text = $"{count}";
			break;
			case 2:
			count = inventory.healingItemAmount;
			countLabel.Text = $"{count}";
			break;
		}

    }
	public void AddFood()
	{
		if(inventory.money >= price)
		{
			inventory.RemoveMoney(price);
			inventory.AddFood();
			buySFX.Play();
		}
	}
	public void AddDrink()
	{
		if(inventory.money >= price)
		{
			inventory.RemoveMoney(price);
			inventory.AddDrinks();
			buySFX.Play();
		}
	}
	public void AddHealth()
	{
		if(inventory.money >= price)
		{
			inventory.RemoveMoney(price);
			inventory.AddHeals();
			buySFX.Play();
		}
	}
	public void UpgradeHealthFactor()
	{
		if(inventory.money >= price)
		{
			inventory.RemoveMoney(price);
			inventory.healingFactor += 2f;
			count++;
			buySFX.Play();
		}
	}
	public void UpgradeDrinkFactor()
	{
		if(inventory.money >= price)
		{
			inventory.RemoveMoney(price);
			inventory.drinkUpFactor += 2f;
			count++;
			buySFX.Play();
		}
	}
	public void UpgradeFoodFactor()
	{
		if(inventory.money >= price)
		{
			inventory.RemoveMoney(price);
			inventory.foodEatFactor += 2f;
			count++;
			buySFX.Play();

		}
	}
	public void OnBuyButtonDown()
	{
		switch (ID)
		{
			case 0:
			AddFood();
			break;
			case 1:
			AddDrink();
			break;
			case 2:
			AddHealth();
			break;
			case 3:
			UpgradeFoodFactor();
			break;
			case 4:
			UpgradeDrinkFactor();
			break;
			case 5:
			UpgradeHealthFactor();
			break;
		}
		countLabel.Text = $"{count}";
	}
}
