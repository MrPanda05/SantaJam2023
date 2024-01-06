using Godot;
using System;
using System.Diagnostics;

/// <summary>
/// Base Item Class
/// </summary>
public partial class Item : Node2D
{
    [Export]public float price = 5.0f;
    [Export]public string description = "Fruit test";
    [Export]public int ID = 0;
    [Export]public string itemName;
    [Export] public Texture2D itemSprite;

    /// <summary>
    /// Add this item to the player inventory Use on _OnReady()
    /// </summary>
    protected void AddSelfToIventory()
    {
        InventoryManager.Instance.AddNewItem(itemName);
    }
    protected void SetProcess()
    {
        if(Visible)
        {
            Show();
            ProcessMode = ProcessModeEnum.Inherit;
            SetProcess(true);
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
        else
        {
            Hide();
            ProcessMode = ProcessModeEnum.Disabled;
            SetProcess(false);
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }
    }
}
