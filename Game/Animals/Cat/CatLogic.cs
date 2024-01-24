using Godot;
using System;


public partial class CatLogic : InteractableLogic
{
    public Cat cat;

    private AnimalStats stats;
    public override void AddThisToInventory()
    {
        InventoryManager.Instance.AddAnimal(cat.ID, cat);
        ChangeMyParent("../../Player/Inventory", "../..");
        DisableProcess(cat);
        cat.Visible = false;
        foreach (Node node in cat.GetChildren())
        {
            DisableProcess(node);
        }
    }

    public void myInteraction()
    {
        cat.Sound();
        AddThisToInventory();
        //FSM.TransitioToState("Wander");
    }

    public void onPet()
    {
        cat.Sound();
        var scene = cat.GetAnimalPathScene();
        var insta = GD.Load<PackedScene>(scene).Instantiate();
        GetParent().GetParent().AddChild(insta);
    }
	public override void _Ready()
	{
        cat = GetNode<Cat>("..");
        stats = GetNode<AnimalStats>("../Stats");
        GetReady();
		area.OnInteract += myInteraction;
        area.OnPet += onPet;
        GD.Print(stats.GetPath());
        FSM = GetNodeOrNull<FiniteStateMachine>("../FSM");
	}
}
