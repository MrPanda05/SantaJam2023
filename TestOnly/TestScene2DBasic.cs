using Godot;
using System;

public partial class TestScene2DBasic : Node2D
{

    public override void _Ready()
    {
        InstanceTest.Instance.PrintSomething("I came from an instance");
    }
}
