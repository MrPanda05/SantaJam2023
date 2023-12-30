using Godot;
using System;

//Base class for interactable logic
public partial class InteractableLogic : Node2D
{
	public InteractableArea area;
    [Export] public string labelText = "[Q] to interact";
    [Export] public bool isSpecial;
    [Export] public string stateToChange = "Pinteracting";

    private Label label;

    /// <summary>
    /// Virtual method for destroying whole node parent, made virtual in case needs to be changed
    /// </summary>
    public virtual void DeleteSelf()
    {
        area.OnEnter -= EnableLabel;
        area.OnExit -= DisableLabel;
        GetParent().QueueFree();
    }


    /// <summary>
    /// Set up the basics dependecies.
    /// Should be calledo OnReady()
    /// </summary>
    public void GetReady()
    {
        area = GetParent().GetNode<InteractableArea>("InteractableArea");
        label = GetParent().GetNode<Label>("Label");
        area.OnEnter += EnableLabel;
        area.OnExit += DisableLabel;
        label.Text = labelText;
        area.SetIsSpecial(isSpecial);
        area.SetStateString();
    }
    public void EnableLabel()
    {
        label.Visible = true;
    }
    public void DisableLabel()
    {
        label.Visible = false;
    }

    public ItemBaseClassTest GetMyNodeParent()
    {
        return (ItemBaseClassTest)GetParent();
    }
}
