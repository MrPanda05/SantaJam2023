using Godot;
using System;

public partial class SettingsUi : Control
{
	public Control mainMenuUI, settingsUI;

	[Export] public AudioStreamPlayer soundTest, masterTest;

	public void OnSettingsButtonButtonDown()
	{
		mainMenuUI.Visible = true;
		settingsUI.Visible = false;
	}

	public void OnMasterVolumeValueChanged(float value)
	{
		AudioServer.SetBusVolumeDb(0, Mathf.LinearToDb(value));
		
	}

	public void OnSoundFxVolumeValueChanged(float value)
	{
		AudioServer.SetBusVolumeDb(2, Mathf.LinearToDb(value));

	}
	public void OnMusicVolumeValueChanged(float value)
	{
		AudioServer.SetBusVolumeDb(1, Mathf.LinearToDb(value));
	}

	public void OnTestMasterButtonDown()
	{
		masterTest.Play();
	}
	public void OnTestSoundsButtonDown()
	{
		soundTest.Play();
	}

	public override void _Ready()
    {
        settingsUI = GetNode<Control>(".");
		mainMenuUI = GetNode<Control>("../MainMenuUI");
    }
}
