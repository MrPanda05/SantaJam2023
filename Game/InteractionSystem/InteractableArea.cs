using Godot;
using System;

//Area that will be interacted by the player
public partial class InteractableArea : Area2D
{
    private bool isSpecial = false;
    private string stateToChange;
    public Action OnInteract;
    public Action OnEnter, OnExit;

    public bool GetIsSpecial()
    {
        return isSpecial;
    }
    public string GetStateString()
    {
        return stateToChange;
    }
    public void SetStateString(string newState = "Pinteracting")
    {
        stateToChange = newState;
    }
    public void SetIsSpecial(bool boolean)
    {
        isSpecial = boolean;
    }
    public void OnAreaEnter(Area2D area)
    {
        GD.Print("Register");
        OnEnter?.Invoke();
        InteractableManager.Instance.Register(this);
    }
    public void OnAreaExit(Area2D area)
    {
        GD.Print("UnRegister");
        OnExit?.Invoke();
        InteractableManager.Instance.UnRegister(this);

    }
}