using Godot;
using System;
using System.Collections.Generic;

public partial class Animal : CharacterBody2D
{
    //General information
    public string animalName {get; protected set;}
    public string animalType {get; protected set;}
    public string description {get; protected set;}
    public uint ID {get; protected set;}
    //[Export]public Sprite2D artForUI;

    private string[] names = {"Larry", "Jessica", "Ana", "Popy", "Richard", "Ellie", "FluffBall", "BallCat", "BallDog", "BlueBirdo", "Amon", "Valk", "Aby", "Abby", "Abigail", "Choco", "Melon", "Punpun", "Vanilla", "Sans", "Bullet", "MousePad", "Peanut", "FluffyPuffy", "PuffPuff", "Melissa", "Caramelo", "Destroyer of Universes", "Princess", "Cinnamon", "Fizz", "Buzz", "Freddy", "Bonnie", "Alex", "Steve", "Elon", "Dusk", "Hirohito", "Guts", "Nuts", "Beast", "Acordion", "Negan", "Rick", "Jason", "Gator", "Larissa", "KeyBoard", "Isaac", "Evee", "Cain", "Inheri", "Composi", "Mouse", "Le Big Mouse", "Marcos", "Pentium8000", "Sausage", "Linguicinha", "Otaku", "Nick", "Gaby", "Bibi", "GigatonGames", "GutonGames", "Pedro", "Dalunciu", "Caveira", "Birdo", "Susie", "Ralsei", "Asriel", "Mexico", "Araki", "Gordon Freeman", "Gordon", "Vance", "54hd03jhgkdsjhowo4h540dfhsldcfu50-4lfffffff54"};

    //Components
    public InteractableArea area;
    public FiniteStateMachine FSM;

    public void SetRandomNameOnStart()
    {
        var rand = new Random();
        int newNum = rand.Next(names.Length - 1);
        animalName = names[newNum];
    }
    public void SetDescritipion(string newDesc)
    {
        description = newDesc;
    }
    public void SetName(string newName)
    {
        animalName = newName;
    }

    public NodePath GetNodePath()
    {
        return GetPath();
    }
    public string GetSceneFilePath()
    {
        return SceneFilePath;
    }
    public virtual void AddToInventory() 
    {
        GD.Print($"Added {animalName} to iventory");
        InventoryManager.Instance.AddAnimal(ID, this);//Add to iventory
        area.OnInteract -= AddToInventory;
        InteractManager.Instance.SetIsInteract(false);
        //GD.Print($"my node path is {SceneFilePath}");
        //var scene = GD.Load<PackedScene>(SceneFilePath);
        //var inst = scene.Instantiate();
        //GetParent().AddChild(inst);
        QueueFree();
    }

    public uint GenerateID(string hash)
    {
        string newHash = hash + (GD.Randi() % 300).ToString();
        GD.Seed(newHash.Hash());
        return GD.Randi();
    }
}
