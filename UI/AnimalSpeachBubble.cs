using Godot;
using System;

public partial class AnimalSpeachBubble : Control
{
	public Animal animal;
	public Inventory inventory;
	public Label speech;
	public float health, hunger, thirst, maxHealth, maxHunger, maxThirst;
	public Timer timer;

	public int GetTheStateStatus(float myCurrentStat, float myMaxStat)
	{
		if(myCurrentStat == myMaxStat)
		{
			GD.Print("Don't need anything");
			return 0;
		}
		if((myCurrentStat >= myMaxStat * 0.8f) && (myCurrentStat < myMaxStat))
		{
			GD.Print("Don't need, but if given it will be nice");
			return 1;
 		}
		if((myCurrentStat >= myMaxStat * 0.5f) && (myCurrentStat < myMaxStat * 0.8f))
		{
			GD.Print("Need something");
			return 2;
		}
		if((myCurrentStat >= myMaxStat * 0.2f) && (myCurrentStat < myMaxStat * 0.5f))
		{
			GD.Print("Really need something");
			return 3;
		}
		if(myCurrentStat < myMaxStat * 0.2f)
		{
			GD.Print("Need now or death is iminent");
			return 4;
		}
		return -1;
	}

	public void SetDrinksText(int drinks)
	{
		uint temp = GD.Randi() % 11;
		if(drinks == 0)
		{
			//Is not thirst
			speech.Text = "Hmm... being hydrated is good";
			return;
		}
		if(drinks == 1)
		{
			//Is not thirst but something 
			switch(temp)
			{
				case 0:
				speech.Text = "I think something refreashing would be nice";
				break;
				default:
				speech.Text = "What will you give for me to drink later?";
				break;
			}
			return;
		}
		if(drinks == 2)
		{
			//Is thirst
			switch(temp)
			{
				case 0:
				speech.Text = "I am getting a bit thirsty";
				break;
				case 1:
				speech.Text = "I think its a good time for you to give me some drinks";
				break;
				default:
				speech.Text = "I am thirsty, I demand something to drink!";
				break;
			}
			return;
		}
		if(drinks == 3)
		{
			//Is very thirst
			switch(temp)
			{
				case 0:
				speech.Text = "I am feeling very thirsty, I really need something to drink";
				break;
				case 1:
				speech.Text = "Please.... give me something to drink!!";
				break;
				default:
				speech.Text = "I am really need water or something!!!";
				break;
			}
			return;
		}
		if(drinks == 4)
		{
			//Dehadrating
			switch(temp)
			{
				case 0:
				speech.Text = "I am feeling very thirsty, I really need something to drink";
				break;
				case 1:
				speech.Text = "Please.... give me something to drink!!";
				break;
				default:
				speech.Text = "I am really need water or something!!!";
				break;
			}
			return;
		}
	}
	public void SetHungryText(int hungrys)
	{
		uint temp = GD.Randi() % 11;
		if(hungrys == 0)
		{
			//Is not thirst
			speech.Text = "UwU I am quite full!";
			return;
		}
		if(hungrys == 1)
		{
			//Is not thirst but something 
			switch(temp)
			{
				case 0:
				speech.Text = "I think some snacks would be nice";
				break;
				default:
				speech.Text = "What will you cook for me later? UwU";
				break;
			}
			return;
		}
		if(hungrys == 2)
		{
			//Is thirst
			switch(temp)
			{
				case 0:
				speech.Text = "I am getting a bit hungry";
				break;
				case 1:
				speech.Text = "I think its a good time for you to give me some food";
				break;
				case 2:
				speech.Text = "I think its time for you to give me somethingto eat! >:3";
				break;
				default:
				speech.Text = "I am hungry, I demand something to eat!";
				break;
			}
			return;
		}
		if(hungrys == 3)
		{
			//Is very thirst
			switch(temp)
			{
				case 0:
				speech.Text = "I am feeling very hungry, I really need something to eat";
				break;
				case 1:
				speech.Text = "Please.... give me something to eat!!";
				break;
				default:
				speech.Text = "I am really need foooooood!!";
				break;
			}
			return;
		}
		if(hungrys == 4)
		{
			//Dehadrating
			switch(temp)
			{
				case 0:
				speech.Text = "I am starving!!!";
				break;
				case 1:
				speech.Text = "Please.... give me something to eat!!";
				break;
				default:
				speech.Text = "I am really need food!! please I beg you...";
				break;
			}
			return;
		}
	}
	public void SetHealthText(int healths)
	{
		uint temp = GD.Randi() % 4;
		if(healths == 0)
		{
			//Is not thirst
			speech.Text = "UwU I am quite healthy init?";
			return;
		}
		if(healths == 1)
		{
			//Is not thirst but something 
			switch(temp)
			{
				default:
				speech.Text = "I think I've go some scratches on me!";
				break;
			}
			return;
		}
		if(healths == 2)
		{
			//Is thirst
			switch(temp)
			{
				case 0:
				speech.Text = "I think I am a bit sick...";
				break;
				case 1:
				speech.Text = "I am not feeling to well..";
				break;
				case 2:
				speech.Text = "I think I need some painkillers";
				break;
				default:
				speech.Text = "Give me a band aid! please...";
				break;
			}
			return;
		}
		if(healths == 3)
		{
			//Is very thirst
			switch(temp)
			{
				case 0:
				speech.Text = "I am so sick right now... :(";
				break;
				case 1:
				speech.Text = "My head is exploding";
				break;
				default:
				speech.Text = "Hmm... not feeling too well... I think I may be hurt...";
				break;
			}
			return;
		}
		if(healths == 4)
		{
			//Dehadrating
			switch(temp)
			{
				case 0:
				speech.Text = "I am dying";
				break;
				case 1:
				speech.Text = "I don't wanna die...";
				break;
				default:
				speech.Text = "hm.. I think my end is near";
				break;
			}
			return;
		}
	}
	public void TextBubble()
	{
		//-maxHealth == 100%
		//-health == Y%
		//maxHealth * Y% == health*100%
		uint temp = GD.Randi() % 3;// 0 - hunger | 1 - thirst| 2 - health| 3 - casual
		switch (temp)
			{
				case 0:
				SetHungryText(GetTheStateStatus(hunger, maxHunger));
				break;
				case 1:
				SetDrinksText(GetTheStateStatus(thirst, maxThirst));
				break;
				case 2:
				SetHealthText(GetTheStateStatus(health, maxHealth));
				break;
			}
			return;
	}
	public void OnTimerTimeout()
	{
		health = animal.healthComponent.health;
		maxHealth = animal.healthComponent.maxHealth;
		hunger = animal.hungerComponent.hunger;
		maxHunger = animal.hungerComponent.maxHunger;
		thirst = animal.thirstComponent.thirst;
		maxThirst = animal.thirstComponent.maxThirst;
		TextBubble();
	}

    public override void _Ready()
    {
        animal = GetNode<Animal>("../Animal");
		inventory = GetNode<Inventory>("../Inventory");
		speech = GetNode<Label>("TextureRect/Label");
		timer = GetNode<Timer>("Timer");
		speech.Text = "Hello... I hope you take care of me!";
    }
}
