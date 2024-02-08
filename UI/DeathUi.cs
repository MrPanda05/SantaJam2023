using Godot;
using System;

public partial class DeathUi : Control
{
	public void OnRestartButtonDown()
	{
		GetTree().ReloadCurrentScene();
		GetTree().Paused = false;
	}
	public void OnQuitButtonDown()
	{
		GetTree().Quit();
	}
}
