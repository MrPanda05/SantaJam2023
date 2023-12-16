using Godot;
using System;

public partial class InteractableTest : Node2D
{


    private InteractableArea interactableArea;



    private void test()
    {
        GD.Print("test gamer penis");
    }


    public override void _Ready()
    {
        interactableArea = GetNode<InteractableArea>("InteractableArea");
        interactableArea.OnInteract += test;

    }
}
