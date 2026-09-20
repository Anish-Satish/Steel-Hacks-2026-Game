using Godot;
using System;

public partial class MainMenuButtons : Godot.VBoxContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

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
	public void _on_quit_pressed()
	{
		GetTree().Quit();
	}
}
