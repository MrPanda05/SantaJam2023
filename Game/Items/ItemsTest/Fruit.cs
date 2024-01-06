using Godot;
using System;
using System.Collections.Generic;
//Example of item class being used
//Here could be added more things
public partial class Fruit : Item
{

    public Fruit()
    :base()
    {
        itemName = "Fruit";
    }
    public override void _Ready()
    {
        AddSelfToIventory();
        SetProcess();
    }
}
