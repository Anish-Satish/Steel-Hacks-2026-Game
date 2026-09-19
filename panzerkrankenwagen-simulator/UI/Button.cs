using Godot;
using System;

public partial class VBoxContainer : Godot.VBoxContainer
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
		GetTree().Root.AddChild(Main.getDriveScene);
		GetTree().Root.RemoveChild(Main.getMainScene);
		
	}

	public void _on_options_pressed()
	{
		GetTree().Root.AddChild(Main.getOptionsScene);
	}
	public void _on_quit_pressed()
	{
		GetTree().Quit();
	}
}
