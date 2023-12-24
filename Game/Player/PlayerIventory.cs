using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerIventory : Node
{
    //Items iventory;
    public Dictionary<string, int> Items = new Dictionary<string, int>();

    //Animals
    public Dictionary<uint, Animal> Animals = new Dictionary<uint, Animal>();

    public int money = 0;

    // public List<Animal> animalList = new List<Animal>();

    // [Export] public Node AnimalIventory;


}
