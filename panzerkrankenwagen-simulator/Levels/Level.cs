using Godot;
using System;

public partial class Level : Node3D
{
	Timer timer;
	public override void _Ready()
	{
<<<<<<< Updated upstream
		timer = GetNode<Timer>("Timer");
		timer.setCountdownTime(0.7f, 3);
=======
>>>>>>> Stashed changes
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_cancel") || Input.IsActionJustPressed("P"))
		{
			GetTree().Paused = true;
			GetTree().Root.AddChild(Main.pauseScene.Instantiate());

		}
	}
}
