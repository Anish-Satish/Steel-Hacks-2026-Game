using Godot;
using System;

public partial class Level : Node3D
{
	// Called when the node enters the scene tree for the first time.
	Timer timer;
	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
		timer.setCountdownTime(0.7f, 3);
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsKeyPressed(Key.Escape) || Input.IsKeyPressed(Key.P))
		{
			GetTree().Paused = true;
			GetTree().Root.AddChild(Main.getPauseScene);
		}
	}
}
