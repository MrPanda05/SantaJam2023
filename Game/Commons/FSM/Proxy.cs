using Godot;
using System;
public interface IProxy
{
    CharacterBody2D myMaster {get; set;}
    AnimalStats myStats{get; set;}
    InteractableLogic myLogic{get; set;}
    Animal myAnimal {get; set;}


}
