using Godot;
using System;

public partial class HealthComponent : Node2D
{

    [Export] public int health = 0;
    [Export] public int imunity = 0;
    [Export] public bool isInjured = false;
    [Export] public int typeInjured = 0;

    public Action OnGetInjured;
}
