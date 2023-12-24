using Godot;
using System;

public partial class InteractableArea : Area2D
{
    [Export] private string interactionString = "Interaction";

    public Action OnInteract;

    public void OnAreaEnter(Area2D area)
    {
        GD.Print("Register");
        InteractManager.Instance.Register(this);
    }
    public void OnAreaExit(Area2D area)
    {
        GD.Print("UnRegister");
        InteractManager.Instance.UnRegister(this);

    }
}
