using Godot;
using System;

public partial class TestComposition : Node2D
{
    //Get the healthcomponent
    [Export] private TestHealthComponent healthComponent;
    public override void _Ready()
    {
        //Use of the healthComponent
        healthComponent?.doDamage();
    }
}
