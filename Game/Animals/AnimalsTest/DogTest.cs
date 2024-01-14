using Godot;
using System;

public partial class DogTest : BaseAnimal
{
    [Export] public float speed = 50;

    public AnimalDropLogic logicDrop;
    public Action ReachDestination;

    public DogLogic dogLogic;
    public void GoTo(Vector2 dir, float delta)
    {
        if(GlobalPosition == dir)
        {
            ReachDestination?.Invoke();
        }
        GlobalPosition = GlobalPosition.MoveToward(dir, delta * speed);
        MoveAndSlide();
    }
    public override void Sound()
    {
        GD.Print("Wolf");
    }
    public void DropLogic(uint ids)
    {
        if(ids != ID)
        {
            return;
        }
        dogLogic.EnableProcess(this);
        Visible = true;
        foreach (Node node in GetChildren())
        {
            dogLogic.EnableProcess(node);
        }
        dogLogic.ChangeMyParent(GetParent().GetParent().GetParent().GetPath(), GetParent().GetPath(), this);
        GlobalPosition = GetNode<CharacterBody2D>("../Player").GlobalPosition;
       
    }

    public override void _Ready()
    {
        ID = GD.Randi();
        GD.Print(ID);
        GD.Print(GetAnimalPathScene());
        logicDrop = GetNode<AnimalDropLogic>("../Camera2D/UIinventory/AnimalDrop");
        dogLogic = GetNode<DogLogic>("DogLogic");
        logicDrop.OnDropAnimal += DropLogic;
    }
}
