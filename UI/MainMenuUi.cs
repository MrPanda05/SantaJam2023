using Godot;
using System;

public partial class MainMenuUi : Control
{
	[Export] public PackedScene mainScene;

	public Control mainMenuUI, settingsUI;

	public void OnStartButtonButtonDown()
	{
		GetTree().ChangeSceneToFile("res://Scenes/MainScene.tscn");
	}

	public void OnSettingsButtonButtonDown()
	{
		settingsUI.Visible = true;
		mainMenuUI.Visible = false;
	}


	public override void _Ready()
    {
        mainMenuUI = GetNode<Control>(".");
		settingsUI = GetNode<Control>("../SettingsUI");
    }
}
