using Godot;
using System;

public partial class PauseMenue : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	public void _on_quit_pressed()
	{
		GetTree().Quit();
	}
	public void _on_resume_pressed()
	{
		GetTree().Paused = false;
		GetTree().Root.RemoveChild(Main.getPauseScene);
	}

	public void _on_restart_pressed()
	{
		//todo Reset variables and re-initialize start of game
	}
	public void _on_options_pressed()
	{
		GetTree().Root.AddChild(Main.getOptionsScene);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsKeyPressed(Key.Escape))
		{
			GetTree().Paused = false;
			GetTree().Root.RemoveChild(Main.getPauseScene);
		}
	}
}
