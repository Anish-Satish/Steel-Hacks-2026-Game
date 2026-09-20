using Godot;
using System;

public partial class Main : Node
{
	// Called when the node enters the scene tree for the first time.
	public static Node driveScene;
	public static Node optionsScene;
	public static Node mainScene;
	public static Node pauseScene;
	public static Node gameOverScene;

	public static int volume;
	public static int MAX_NPC_COUNT;
	public override void _Ready()
	{
		//todo assign the scenes to the correct command directory
		driveScene = ResourceLoader.Load<PackedScene>("res://Levels/level.tscn").Instantiate();
		optionsScene = ResourceLoader.Load<PackedScene>("res://UI/Options/Options.tscn").Instantiate();
		mainScene = ResourceLoader.Load<PackedScene>("res://UI/MainMenu/MainMenue.tscn").Instantiate();
		pauseScene = ResourceLoader.Load<PackedScene>("res://UI/PauseMenu/PauseMenue.tscn").Instantiate();
		gameOverScene = ResourceLoader.Load<PackedScene>("res://UI/GameOver/game_over.tscn").Instantiate();

		volume = 80;
		MAX_NPC_COUNT = 60;
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
	public static Node getGameOverScene
	{
		get {return gameOverScene;}
	}
	public static int getVolume
	{
		get {return volume;}

	}
	public static int getMAX_NPC_COUNT
	{
		get {return MAX_NPC_COUNT;}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
