using Godot;
using System;

public partial class SignalsTest : Node2D
{
    //GODOT EXCLUSIVE FEATURE
    //Signals are always from this external file, I don't know why I can do them from the same file
    [Signal]
    //Custon signal, must have EventHandler at the end
    public delegate void HealthDepletedEventHandler();
    //This file can be put as a singletoon as well

}
