using Godot;
using System;

public partial class BaseAnimal : CharacterBody2D
{
    public uint ID;
    [Export]public string animalName;
    [Export]public string description;
    [Export]public string animalType;

    [Export] public Texture2D itemSprite;

    public virtual void Sound()
    {
        GD.Print("I go pingas");
    }
    public NodePath GetAnimalPathScene()
    {
        return SceneFilePath;
    }

}
