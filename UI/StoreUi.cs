using Godot;
using System;

public partial class StoreUi : Control
{
	public Node2D AnimalScene, ShopScene;

	public Animal animal;
	private Inventory inventory;
	public Label moneyLabel;

	public void OnReturnButtonDown()
	{	
		AnimalScene.Visible = true;
		ShopScene.Visible = false;
		animal.timer.WaitTime = 3.1f;
		
	}
	public void UpdateMoney()
	{
		moneyLabel.Text = $"M$: {inventory.money}";
	}
    public override void _Ready()
    {
        AnimalScene = GetNode<Node2D>("../../AnimalScene");
		ShopScene = GetNode<Node2D>("../../Store");
		animal = GetNode<Animal>("../../AnimalScene/Animal");
		inventory = GetNode<Inventory>("../../AnimalScene/Inventory");
		moneyLabel = GetNode<Label>("MoneyLabel");
		inventory.OnInventoryUpdate += UpdateMoney;
		UpdateMoney();

    }
}
