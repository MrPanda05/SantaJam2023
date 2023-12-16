using Godot;
using System;

public partial class Cat : BaseAnimal
{
    private InteractableArea interactable;
    public override void AnimalSound()
    {
        GD.Print("meow nigga");
    }

    public override void _Ready()
    {
        interactable = GetNode<InteractableArea>("InteractableArea");
        interactable.OnInteract += AnimalSound;
    }


}
