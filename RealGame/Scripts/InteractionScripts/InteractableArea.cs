using Godot;
using System;

public partial class InteractableArea : Area2D
{
    [Export] private string interactionString = "Interaction";

    public Action OnInteract;

    public void OnAreaEntered(Area2D area)
    {
        GD.Print("Register");
        InteractorManager.InteractorInstance.Register(this);
    }
    public void OnAreaExited(Area2D area)
    {
        GD.Print("UnRegister");
        InteractorManager.InteractorInstance.UnRegister(this);
    }

    
}
