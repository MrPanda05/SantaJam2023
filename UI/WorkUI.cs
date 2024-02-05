using Godot;
using System;

public partial class WorkUI : Control
{
	public Node2D AnimalScene, WorkScene;
	public RocksSpawner spawner;

	public Inventory inventory;

	public Label rockLabel, goldLabel, ironLabel, moneyLabel;

	public Animal animal;
	public void OnUpdateLabels()
	{
		rockLabel.Text = $"Rock: {spawner.rockCount}";
		ironLabel.Text = $"Iron: {spawner.ironCount}";
		goldLabel.Text = $"Gold: {spawner.goldCount}";
	}
	public void OnSellRockButtonDown()
	{
		int moneyTemp = spawner.rockCount * 4;
		spawner.rockCount = 0;
		inventory.AddMoney(moneyTemp);
		UpdateMoneyLable();
		OnUpdateLabels();
	}
	public void OnSellIronButtonDown()
	{
		int moneyTemp = spawner.ironCount * 8;
		spawner.ironCount = 0;
		inventory.AddMoney(moneyTemp);
		UpdateMoneyLable();
		OnUpdateLabels();
	}
	public void OnSellGoldButtonDown()
	{
		int moneyTemp = spawner.goldCount * 20;
		spawner.goldCount = 0;
		inventory.AddMoney(moneyTemp);
		UpdateMoneyLable();
		OnUpdateLabels();
	}
	public void OnSellAllButtonDown()
	{
		OnSellRockButtonDown();
		OnSellIronButtonDown();
		OnSellGoldButtonDown();
	}
	public void UpdateMoneyLable()
	{
		moneyLabel.Text = $"M$ {inventory.money}";
	}
	public void OnStopButtonDown()
	{
		AnimalScene.Visible = true;
		WorkScene.Visible = false;
		animal.timer.WaitTime = 3.1f;
	}

    public override void _Ready()
    {
        AnimalScene = GetNode<Node2D>("../../AnimalScene");
		WorkScene = GetNode<Node2D>("../../Work");
		spawner = GetNode<RocksSpawner>("../Mining/RocksSpawner");
		rockLabel = GetNode<Label>("RockLabel");
		goldLabel = GetNode<Label>("GoldLabel");
		ironLabel = GetNode<Label>("IronLabel");
		moneyLabel = GetNode<Label>("MoneyLabel");
		inventory = GetNode<Inventory>("../../AnimalScene/Inventory");
		animal = GetNode<Animal>("../../AnimalScene/Animal");
		spawner.OnUpdate += OnUpdateLabels;
		inventory.OnInventoryUpdate += UpdateMoneyLable;
		UpdateMoneyLable();
    }
}
