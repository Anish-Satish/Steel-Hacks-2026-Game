using Godot;
using System;

public partial class Main : Node
{
	// Called when the node enters the scene tree for the first time.
	public static Node driveScene;
	public static Node optionsScene;
	public static Node mainScene;
	public static Node pauseScene;
	public override void _Ready()
	{
		//todo assign the scenes to the correct command directory
		driveScene = ResourceLoader.Load<PackedScene>("res://level.tscn").Instantiate();
		optionsScene = ResourceLoader.Load<PackedScene>("res://scene/options.tscn").Instantiate();
		mainScene = ResourceLoader.Load<PackedScene>("res://UI/MainMenue.tscn").Instantiate();
	}

	public static Node getDriveScene
	{
		get { return driveScene; }
	}
	public static Node getOptionsScene
	{
		get { return optionsScene; }
	}
	public static Node getMainScene
	{
		get { return mainScene; }
	}
	public static Node getPauseScene
	{
		get { return pauseScene; }
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
