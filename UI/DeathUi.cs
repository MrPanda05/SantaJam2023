using Godot;
using System;

public partial class DeathUi : Control
{
	public void OnRestartButtonDown()
	{
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
	}
	public void OnQuitButtonDown()
	{
		GetTree().Quit();
	}
}
