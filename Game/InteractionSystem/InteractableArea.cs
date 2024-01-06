using Godot;
using System;

/// <summary>
/// Area that will be interacted by the player
/// </summary>
public partial class InteractableArea : Area2D
{
    /// <summary>
    /// Set if the current interaction will trigger a state change
    /// </summary>
    private bool isSpecial = false;
    /// <summary>
    /// The state that will change when triggering
    /// </summary>
    private string stateToChange;
    /// <summary>
    /// Events for interactions
    /// </summary>
    public Action OnInteract, OnPet;
    /// <summary>
    /// Events for when exiting and entering the Interactable manager
    /// </summary>
    public Action OnEnter, OnExit;
    /// <summary>
    /// Get if is special
    /// </summary>
    /// <returns>isSpecial</returns>
    public bool GetIsSpecial()
    {
        return isSpecial;
    }
    /// <summary>
    /// Get the current state string
    /// </summary>
    /// <returns>state string</returns>
    public string GetStateString()
    {
        return stateToChange;
    }
    /// <summary>
    /// Sets a new state string
    /// </summary>
    /// <param name="newState"></param>
    public void SetStateString(string newState = "Pinteracting")
    {
        stateToChange = newState;
    }
    /// <summary>
    /// Sets if current interaction is ispecial
    /// </summary>
    /// <param name="boolean"></param>
    public void SetIsSpecial(bool boolean)
    {
        isSpecial = boolean;
    }
    public void OnAreaEnter(Area2D area)
    {
        //GD.Print("Register");
        OnEnter?.Invoke();
        InteractableManager.Instance.Register(this);
    }
    public void OnAreaExit(Area2D area)
    {
        //GD.Print("UnRegister");
        OnExit?.Invoke();
        InteractableManager.Instance.UnRegister(this);

    }
}