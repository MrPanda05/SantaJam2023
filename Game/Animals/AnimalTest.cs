using Godot;
using System;

public partial class AnimalTest : Animal
{
    [Export] public string typeAnimal;
    [Export]public string descAnimal;

    public override void _Ready()
    {
        FSM = GetNode<FiniteStateMachine>("FiniteStateMachine");
        GD.Print("My name is " + animalName);
        SetRandomNameOnStart();
        description = descAnimal;
        animalType = typeAnimal;
        ID = GenerateID(animalName);
        area = GetNode<InteractableArea>("InteractableArea");
        area.OnInteract += AddToInventory;
    }
}
