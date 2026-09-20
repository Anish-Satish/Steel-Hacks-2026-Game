using Godot;
using System;

public partial class Buttons : HSplitContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void _on_quit_pressed()
	{
		GetTree().Quit();
	}

	public void _on_restart_pressed()
	{
		//todo Reset variables and re-initialize start of game
	}

	public void _on_main_menue_pressed()
	{
		GetTree().ChangeSceneToPacked(Main.mainScene);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
