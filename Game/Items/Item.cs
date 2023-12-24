using Godot;
using System;

public partial class Item : Node2D
{
    [Export]public int rarity;
    [Export]public string itemName;
    [Export]public string description;
    [Export]public float price;
    [Export]public int ID;

    public InteractableArea area;
}
