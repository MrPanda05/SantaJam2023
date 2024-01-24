using Godot;
using System;
using System.Linq;


public partial class Animal : CharacterBody2D
{
    public uint ID;
    public string animalName = "";
    public string description;
    [Export]public string animalType;//if is a cat, dog and so on
    [Export]public Texture2D itemSprite;

    protected string[] names = {"Larry", "Jessica", "Ana", "Popy", "Richard", "Ellie", "FluffBall", "BallCat", "BallDog", "BlueBirdo", "Amon", "Valk", "Aby", "Abby", "Abigail", "Choco", "Melon", "Punpun", "Vanilla", "Sans", "Bullet", "MousePad", "Peanut", "FluffyPuffy", "PuffPuff", "Melissa", "Caramelo", "Destroyer of Universes", "Princess", "Cinnamon", "Fizz", "Buzz", "Freddy", "Bonnie", "Alex", "Steve", "Elon", "Dusk", "Hirohito", "Guts", "Nuts", "Beast", "Acordion", "Negan", "Rick", "Jason", "Gator", "Larissa", "KeyBoard", "Isaac", "Evee", "Cain", "Inheri", "Composi", "Mouse", "Le Big Mouse", "Marcos", "Pentium8000", "Sausage", "Linguicinha", "Otaku", "Nick", "Gaby", "Bibi", "GigatonGames", "GutonGames", "Pedro", "Dalunciu", "Caveira", "Birdo", "Susie", "Ralsei", "Asriel", "Mexico", "Araki", "Gordon Freeman", "Gordon", "Vance", "54hd03jhgkdsjhowo4h540dfhsldcfu50-4lfffffff54", "Sus", "Mousepad",
    "Billy", "Henry", "Chris", "Sam", "Ham", "Godo", "Fanter", "Flopper", "Flopps", "Tissue", "Salami", "Chonker", "Orange", "Spy", "Nails", "Fan", "Grey", "Pingas", "Vim", "Vsbode"};

    protected void SetRandomName()
    {
        GD.Print("set name");
        long index = GD.Randi() % names.Length - 1;
        animalName = names[index];
    }
    public void SetDrescription()
    {
        description = $"Hello, I am a {animalType} and my name is {animalName}";
    }
    public virtual void Sound()
    {
        GD.Print("I go pingas");
    }
    public NodePath GetAnimalPathScene()
    {
        return SceneFilePath;
    }

}