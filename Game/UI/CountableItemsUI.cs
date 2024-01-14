using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public partial class CountableItemsUI : ItemList
{

	public List<string> itemListNames = new List<string>();

	[Export] private Label itemDescriptionLabel;

	public void SetItems()
	{
		foreach (KeyValuePair<string, int> Items in InventoryManager.Instance.playerInventory.countableItems)
		{	
			AddItem($"{Items.Key}: {InventoryManager.Instance.GetItemCount(Items.Key)}", InventoryManager.Instance.GetItemTexture(Items.Key), false);
			itemListNames.Add(Items.Key);
		}
	}
	public void UpdateItems()
	{
		for (int i = 0; i < itemListNames.Count; i++)
		{
			SetItemText(i, $"{itemListNames[i]}: {InventoryManager.Instance.GetItemCount(itemListNames[i])}");
		}
	}

	public void OnItemSelected(int index)
	{
		itemDescriptionLabel.Text = InventoryManager.Instance.GetItemDescription(itemListNames[index]);
		//Todo add a way to disable animaldrop from here because it will be clicking on the item description
	}
    public override void _Ready()
    {
		
		SetItems();
		InventoryManager.OnItemIncrementCount += UpdateItems;
        
    }
}
