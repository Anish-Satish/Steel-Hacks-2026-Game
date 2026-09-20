using Godot;
using System;

public partial class Main : Node
{
	// Called when the node enters the scene tree for the first time.
	public static PackedScene driveScene;
	public static PackedScene optionsScene;
	public static PackedScene mainScene;
	public static PackedScene pauseScene;
	public override void _Ready()
	{
		//todo assign the scenes to the correct command directory
		driveScene = ResourceLoader.Load<PackedScene>("res://Levels/level.tscn");
		mainScene = ResourceLoader.Load<PackedScene>("res://UI/MainMenue.tscn");
	}

	public static PackedScene getDriveScene
	{
		get { return driveScene; }
	}
	public static PackedScene getOptionsScene
	{
		get { return optionsScene; }
	}
	public static PackedScene getMainScene
	{
		get { return mainScene; }
	}
	public static PackedScene getPauseScene
	{
		get { return pauseScene; }
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
