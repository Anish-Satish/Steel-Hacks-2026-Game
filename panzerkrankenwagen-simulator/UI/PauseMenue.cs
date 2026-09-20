using Godot;
using System;

public partial class PauseMenue : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD:panzerkrankenwagen-simulator/UI/Main Menu/Button.cs

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{	}

	public void _on_drive_pressed()
	{
		// GetTree().Root.AddChild(Main.getDriveScene);
		// GetTree().Root.RemoveChild(Main.getMainScene);
		GetTree().Root.AddChild(Main.getDriveScene);
		GetTree().Root.RemoveChild(Main.getMainScene);
		Console.WriteLine("Drive pressed");
		
	}

	public void _on_options_pressed()
	{
		GetTree().Root.AddChild(Main.getOptionsScene);
		GetTree().Root.RemoveChild(Main.getMainScene);
	}
=======
>>>>>>> parent of f50f0c7 (time t okill):panzerkrankenwagen-simulator/UI/PauseMenue.cs
=======
>>>>>>> parent of f50f0c7 (time t okill)
=======
>>>>>>> parent of f50f0c7 (time t okill)
=======
>>>>>>> parent of f50f0c7 (time t okill)
	public void _on_quit_pressed()
	{
		GetTree().Quit();
	}
	public void _on_resume_pressed()
	{
		GetTree().ChangeSceneToPacked(Main.getDriveScene);
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
