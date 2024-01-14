using Godot;
using System;
using System.Linq;

public partial class PanelComponent : Panel
{
	private AnimalsUI animalsUI;

	public Panel AnimalDrop;

	public int myIndex = -1;

	private Label animalLabelDrop, description;

	public AnimalDropLogic UIDropLogic;

	public TextureRect animalTexture;

	public BaseAnimal myAnimal;

	

	public void SetVisibility()
	{
		if(animalTexture.Texture != null)
		{
			if(!AnimalDrop.Visible)
			{
				AnimalDrop.Visible = true;
			}
		}
		else
		{
			AnimalDrop.Visible = false;
		}

	}

	public void SetTexts()
	{
		if(myIndex < animalsUI.animals.Count)
		{
			animalLabelDrop.Text = $"Drop {animalsUI.animals[myIndex].Name}?";
			description.Text = $"{animalsUI.animals[myIndex].description}";
		}
	}
	public BaseAnimal SetAnimalOnUI()
	{
		//index >= 0 && index < array.Length
		if(myIndex <= animalsUI.animals.Count - 1)
		{
			GD.Print($" I with ID: {myIndex} Sended {animalsUI.animals[myIndex].Name}");
			return animalsUI.animals[myIndex];
		}
		return null;
	}

	public void OnButtonDown()
	{
		SetVisibility();
		SetTexts();
		UIDropLogic.currentAnimal = SetAnimalOnUI();
	}
	
    public override void _Ready()
    {
        animalsUI = GetNode<AnimalsUI>("..");
		AnimalDrop = GetNode<Panel>("../../AnimalDrop");
		UIDropLogic = GetNode<AnimalDropLogic>("../../AnimalDrop");
		AnimalDrop.Visible = false;
		animalLabelDrop = AnimalDrop.GetNode<Label>("Label");
		description = GetNode<Label>("../../Desc/Label");
		animalTexture = GetNode<TextureRect>("Button/TextureRect");
    }
	
}
