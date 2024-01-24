using Godot;
using System;
using System.Collections.Generic;


public partial class AnimalsUI : GridContainer
{
	public List<Panel> slots = new List<Panel>();
	private List<uint> animalID = new List<uint>();
	public List<Animal> animals = new List<Animal>();

	public void OnAnimalAdded(uint ID, Animal animal)
	{
		AddToTheList(ID, animal);
		//slots[animalID.IndexOf(ID)].GetNode<TextureRect>("Button/TextureRect").Texture = animal.itemSprite;
		slots[animalID.IndexOf(ID)].GetNode<PanelComponent>(".").animalTexture.Texture = animal.itemSprite;
		slots[animalID.IndexOf(ID)].GetNode<PanelComponent>(".").myAnimal = animal;
	}
	public void UpdateUI()
	{
		for (int i = 0; i < 12; i++)
		{
			if(i < animalID.Count)
			{
				slots[i].GetNode<PanelComponent>(".").animalTexture.Texture = animals[i].itemSprite;
				continue;
			}
			slots[i].GetNode<PanelComponent>(".").animalTexture.Texture = null;
		}
		
	}
	public void OnAnimalRemoved(uint ID)
	{
		int index = animalID.IndexOf(ID);
		slots[index].GetNode<PanelComponent>(".").animalTexture.Texture = null;
		RemoteFromList(index);
	}
	public void AddToTheList(uint ID, Animal animal)
	{
		if(!animalID.Contains(ID) && !animals.Contains(animal) && animalID.Count < 12)
		{
			animalID.Add(ID);
			animals.Add(animal);
		}
	}
	public void RemoteFromList(int index)
	{
		animalID.RemoveAt(index);
		animals.RemoveAt(index);
	}

	public int GetIndex(Animal animal)
	{
		return animals.IndexOf(animal);
	}


    public override void _Ready()
    {
		int index = 0;
        foreach (Panel panels in GetChildren())
		{
			slots.Add(panels);
		}
		foreach (PanelComponent item in GetChildren())
		{
			item.myIndex = index;
			index++;
		}
		

		InventoryManager.OnAddAnimal += OnAnimalAdded;
    }
}
