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
		GetTree().Root.AddChild(Main.getDriveScene);
		GetTree().Root.RemoveChild(Main.getPauseScene);
	}
	public void _on_options_pressed()
	{
		GetTree().Root.AddChild(Main.getOptionsScene);
		GetTree().Root.RemoveChild(Main.getPauseScene);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
