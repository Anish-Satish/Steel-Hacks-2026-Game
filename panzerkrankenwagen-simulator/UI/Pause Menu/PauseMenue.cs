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
<<<<<<< Updated upstream:panzerkrankenwagen-simulator/UI/PauseMenue.cs
		GetTree().ChangeSceneToPacked(Main.getDriveScene);
=======
		GetTree().Paused = false;
		GetTree().Root.RemoveChild(Main.getPauseScene);
>>>>>>> Stashed changes:panzerkrankenwagen-simulator/UI/Pause Menu/PauseMenue.cs
	}

	public void _on_restart_pressed()
	{
		//todo Reset variables and re-initialize start of game
	}
	public void _on_options_pressed()
	{
		GetTree().ChangeSceneToPacked(Main.getOptionsScene);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
