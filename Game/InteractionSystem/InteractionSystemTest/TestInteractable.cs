using Godot;
using System;

//A test for how the interactable should react
public partial class TestInteractable : Node2D
{
    public InteractableArea area;
    [Export] public string labelText = "[Q] to interact";
    [Export] public bool isSpecial;
    public void myInteraction()
    {
        if(area.GetIsSpecial())
        {
            area.OnInteract -= myInteraction;
            GD.Print("Is special");
            QueueFree();
        }
        else
        {
            area.OnInteract -= myInteraction;
            GD.Print("Is not special");
            QueueFree();

        }
    }
    public override void _Ready()
    {
        area = GetNode<InteractableArea>("InteractableArea");
        //area.SetLabelText(labelText);
        area.SetIsSpecial(isSpecial);
        area.SetStateString();
        area.OnInteract += myInteraction;
    }
}
