using Godot;
using System;

public partial class Cat : Animal
{
    public AnimalDropLogic logicDrop;
    public Action ReachDestination;
    public CatLogic catLogic;
    private AnimalStats stats;
   
    public override void Sound()
    {
        GD.Print("Meow");
    }
    public void DropLogic(uint ids)
    {
        if(ids != ID)
        {
            return;
        }
        catLogic.EnableProcess(this);
        Visible = true;
        foreach (Node node in GetChildren())
        {
            catLogic.EnableProcess(node);
        }
        //black magic
        catLogic.ChangeMyParent(GetParent().GetParent().GetParent().GetPath(), GetParent().GetPath(), this);
        GlobalPosition = GetNode<CharacterBody2D>("../Player").GlobalPosition;
       
    }

    public override void _Ready()
    {
        SetRandomName();
        SetDrescription();
        ID = GD.Randi();
        logicDrop = GetNode<AnimalDropLogic>("../Camera2D/UIinventory/AnimalDrop");
        catLogic = GetNode<CatLogic>("CatLogic");
        logicDrop.OnDropAnimal += DropLogic;
        stats = GetNode<AnimalStats>("Stats");

    }
}
