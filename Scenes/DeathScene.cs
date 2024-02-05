using Godot;
using System;

public partial class DeathScene : Node2D
{
    public Animal animal;

    public Node2D AnimalScene, WorkScene, ShopScene;

    public Control DeathUI;

    public void Death()
    {
        AnimalScene.Visible = false;
        WorkScene.Visible = false;
        ShopScene.Visible = false;
        DeathUI.Visible = true;
        GetTree().Paused = true;

    }

    public override void _Ready()
    {
        animal = GetNode<Animal>("../../AnimalScene/Animal");
        AnimalScene = GetNode<Node2D>("../../AnimalScene");
        WorkScene = GetNode<Node2D>("../../Work");
        ShopScene = GetNode<Node2D>("../../Store");
        DeathUI = GetNode<Control>("DeathUI");
        animal.healthComponent.OnDeath += Death;
        
    }
}
