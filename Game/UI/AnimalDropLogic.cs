using Godot;
using System;

public partial class AnimalDropLogic : Panel
{
	public BaseAnimal currentAnimal;

	public AnimalsUI animalUI;

	private Button ButtonDrop, ButtonCancel;

	public Action<uint> OnDropAnimal;

	public void OnCancelButtonDown()
	{
		currentAnimal = null;
		Visible = false;
		animalUI.UpdateUI();
	}

	public void OnDropButtonDown()
	{
		GD.Print("Drop");
		OnDropAnimal?.Invoke(currentAnimal.ID);	
		animalUI.OnAnimalRemoved(currentAnimal.ID);
		InventoryManager.Instance.RemoveAnimal(currentAnimal.ID);
		Visible = false;
		animalUI.UpdateUI();
		//todo Shif all element to the left
		//When removing an animal that is not the last of the list, I must shift all elements UI to the UI;
		
	}

    public override void _Ready()
    {
        ButtonDrop = GetNode<Button>("DropButton");
        ButtonCancel = GetNode<Button>("CancelButton");
		animalUI = GetNode<AnimalsUI>("../Animals");
    }
}
