using Godot;
using System;


//Example of a singlepatern godot in c#
public partial class InstanceTest : Node
{
    public static InstanceTest Instance {get; private set; }//Static field with get and private set

    public override void _Ready()
    {
        Instance = this;//Set to this instance of class
    }

    //Basic test method, to access use Instance.Instance.PrintSomething()
    public void PrintSomething(string something)
    {
        GD.Print(something);
    }
}
