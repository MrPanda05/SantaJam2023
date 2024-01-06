using Godot;
using System;

public partial class UIControlComponent : Node2D
{
    public Control UI;

    public void SetVisible()
    {
        //control.Visible = true;
        GD.Print("Visible");
    }
    public void SetInvisible()
    {
        //control.Visible = false;
        GD.Print("Invisible");

    }
}
