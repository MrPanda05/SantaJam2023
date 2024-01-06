using Godot;
using System;

public partial class IddleTest : State
{
    public DogTest Dog;



    public override void Readys()
    {
        Dog = GetNode<DogTest>("../..");
        
        Dog.Sound();
    }
}
