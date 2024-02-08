using Godot;
using System;

public partial class SettingsUi : Control
{
	public Control mainMenuUI, settingsUI;

	public void OnSettingsButtonButtonDown()
	{
		mainMenuUI.Visible = true;
		settingsUI.Visible = false;
	}


	public override void _Ready()
    {
        settingsUI = GetNode<Control>(".");
		mainMenuUI = GetNode<Control>("../MainMenuUI");
    }
}
