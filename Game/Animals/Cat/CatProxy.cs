using Godot;
using System;

public partial class CatProxy : Node, IProxy
{
    public CharacterBody2D myMaster {get; set;}
    public AnimalStats myStats{get; set;}
    public InteractableLogic myLogic{get; set;}
    public Animal myAnimal {get; set;}

    //public Cat myCat

    public override void _Ready()
    {
        myAnimal = GetNode<Cat>("..");
        myMaster = GetNode<CharacterBody2D>("..");
        myStats = GetNode<AnimalStats>("../Stats");
        myLogic = GetNode<CatLogic>("../CatLogic");
        //GD.Print(this is IProxy);
    }
}
