using Godot;
using System;

public partial class InventoryUi : Control
{
	public Inventory inventory;

	public Label foodLabel, drinkLabel, healLabel, moneyLabel;

	public void UpdateUI()
	{
		foodLabel.Text = $"Food: {inventory.foodAmount}";
		drinkLabel.Text = $"Drinks: {inventory.drinkAmount}";
		healLabel.Text = $"Heals: {inventory.healingItemAmount}";
		moneyLabel.Text = $"M$: {inventory.money}";
	}

    public override void _Ready()
    {
		foodLabel = GetNode<Label>("Food");
		drinkLabel = GetNode<Label>("Drink");
		healLabel = GetNode<Label>("Heal");
		moneyLabel = GetNode<Label>("Money");
        inventory = GetNode<Inventory>("../Inventory");
		inventory.OnInventoryUpdate += UpdateUI;
		UpdateUI();
    }
}
