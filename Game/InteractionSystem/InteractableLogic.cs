using Godot;
using System;

/// <summary>
/// Base class that handles the logic of an object when being interacted
/// This should be used in a component
/// </summary>
public partial class InteractableLogic : Node2D
{
	public InteractableArea area;
    public FiniteStateMachine FSM = null;
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
    public void DisableProcess(Node node)
    {
        node.ProcessMode = ProcessModeEnum.Disabled;
    }
    public void EnableProcess(Node node)
    {
        node.ProcessMode = ProcessModeEnum.Inherit;
    }
    

    //"../../Player/Inventory", "../.." to add animal to inventory and remove from base scene tree
    public void ChangeMyParent(NodePath pathToNewParent, NodePath oldParent)
    {
        Node newParent = GetNode(pathToNewParent);
        GetNode(oldParent).RemoveChild(GetParent());
        newParent.AddChild(GetParent());
    }
    //"../..", testAnimal.GetParent().GetPath(), testAnimal To remove animal from inventory and add to scene tree
    public void ChangeMyParent(NodePath pathToNewParent, NodePath oldParent, Node nodeChange)
    {
        Node newParent = GetNode(pathToNewParent);
        GetNode(oldParent).RemoveChild(nodeChange);
        newParent.AddChild(nodeChange);
    }

    public virtual void AddThisToInventory() {}

    
}
