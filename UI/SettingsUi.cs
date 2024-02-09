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


	public void OnMasterVolumeValueChanged(float value)
	{
		AudioServer.SetBusVolumeDb(0, value);

		if(value == -40)
		{
			AudioServer.SetBusMute(0, true);
		}
		else
		{
			AudioServer.SetBusMute(0, false);
		}
	}

	public void OnSoundFxVolumeValueChanged(float value)
	{
		AudioServer.SetBusVolumeDb(2, value);

		if(value == -40)
		{
			AudioServer.SetBusMute(2, true);
		}
		else
		{
			AudioServer.SetBusMute(2, false);
		}
	}
	public void OnMusicVolumeValueChanged(float value)
	{
		AudioServer.SetBusVolumeDb(1, value);

		if(value == -40)
		{
			AudioServer.SetBusMute(1, true);
		}
		else
		{
			AudioServer.SetBusMute(1, false);
		}
	}


	public override void _Ready()
    {
        settingsUI = GetNode<Control>(".");
		mainMenuUI = GetNode<Control>("../MainMenuUI");
    }
}
