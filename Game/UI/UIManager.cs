using Godot;
using System;

public partial class UIManager : Node
{
    public static UIManager Instance {get; private set;}

    public Control Inventory;

    public override void _Ready()
    {
        Instance = this;
        Inventory = GetNode<Control>("../TestScene/Camera2D/UIinventory");
    }
}
