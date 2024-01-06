using Godot;
using System;

public partial class DogLogic : InteractableLogic
{
    public DogTest Dog;
    public void AddThisToInventory()
    {
        InventoryManager.Instance.AddAnimal(Dog.ID, Dog);
        ChangeMyParent("../../Player/Inventory", "../..");
        DisableProcess(Dog);
        Dog.Visible = false;
        foreach (Node node in Dog.GetChildren())
        {
            DisableProcess(node);
        }
    }

    public void myInteraction()
    {
        Dog.Sound();
        //AddThisToInventory();
        FSM.TransitioToState("Wander");
    }

    public void onPet()
    {
        Dog.Sound();
        var scene = Dog.GetAnimalPathScene();
        var insta = GD.Load<PackedScene>(scene).Instantiate();
        GetParent().GetParent().AddChild(insta);
    }
	public override void _Ready()
	{
        Dog = GetNode<DogTest>("..");
        GetReady();
		area.OnInteract += myInteraction;
        area.OnPet += onPet;
	}
}
