using Godot;
using System;

public partial class AnimalTest : Animal
{
    [Export] public string typeAnimal;
    [Export]public string descAnimal;

    public void Test()
    {
        GD.Print(this.GetType().Name);
    }

    public override void _Ready()
    {
        animalHealthComponent = GetNode<HealthComponent>("HealthComponent");
        animalHealthComponent.OnGetInjured += Test;
        animalHealthComponent.OnGetInjured?.Invoke();
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
