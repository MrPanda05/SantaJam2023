using Godot;
using System;

public partial class Middleware : Node
{
    //{ throw new NotImplementedException();}

    public CharacterBody2D GetCurrentParent()
    {
        return (CharacterBody2D)GetParent().GetParent();
    }
}
