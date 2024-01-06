using Godot;
using System;
public partial class SpawnerOnInteract : InteractableLogic
{

    string file = "";
    
    public void spawn()
    {
        //?Creates a new Item node and adds as child
        //Can be generalized to create any node
        //var newItem = new Item();
        //GetParent().GetParent().AddChild(newItem);


        //?Creates a new scene and instantiates, best results is this way
        //Can be generalized to create any node
        //! this is the best way to instantiate Items so far, since items are the same everywhere
        file = InventoryManager.Instance.GetItemFilePath("Fruit");
        GD.Print(file);
        var pnis = GD.Load<PackedScene>(file).Instantiate();
        GetParent().GetParent().AddChild(pnis);

        //?Creates a new node calling its constructor
        //Can be generalized to create any node
        //var type = InventoryManager.Instance.GetItem("Fruit").GetType();
        //var test = (Node2D)Activator.CreateInstance(type);
        //GetParent().GetParent().AddChild(test);

        //? Remove animal from inventory
        // var testAnimal = InventoryManager.Instance.GetAnimal(2);
        // ChangeMyParent("../..", testAnimal.GetParent().GetPath(), testAnimal);
        // EnableProcess(testAnimal);
        // foreach (Node node in testAnimal.GetChildren())
        // {
        //     EnableProcess(node);
        // }
        // testAnimal.Visible = true;
        // InventoryManager.Instance.RemoveAnimal(2);

    }
    public override void _Ready()
	{
        GetReady();
		area.OnInteract += spawn;
	}
}
