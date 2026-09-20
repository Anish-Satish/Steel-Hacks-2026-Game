using Godot;
using System;

public partial class Main : Node
{
	// Called when the node enters the scene tree for the first time.
	public static PackedScene driveScene;
	public static PackedScene optionsScene;
	public static PackedScene mainScene;
	public static PackedScene pauseScene;
	public static PackedScene gameOverScene;

	public static int volume;
	public static int MAX_NPC_COUNT;
	public override void _Ready()
	{
		//todo assign the scenes to the correct command directory
		driveScene = GD.Load<PackedScene>("res://Levels/level.tscn");
		optionsScene = GD.Load<PackedScene>("res://UI/Options/Options.tscn");
		mainScene = GD.Load<PackedScene>("res://UI/MainMenu/MainMenue.tscn");
		pauseScene = GD.Load<PackedScene>("res://UI/PauseMenu/PauseMenue.tscn");
		gameOverScene = GD.Load<PackedScene>("res://UI/GameOver/game_over.tscn");

		if (driveScene == null)
		{
			Console.WriteLine("drive was not instantiated");
		}
		if (optionsScene == null)
		{
			Console.WriteLine("options scene was not instantiated");
		}
		if (mainScene == null)
		{
			Console.WriteLine("MainScene was not instantiated");
		}
		if (pauseScene == null)
		{
			Console.WriteLine("pauseScene was not instantiated");
		}
		if (gameOverScene == null)
		{
			Console.WriteLine("gameOver Scene was not instantiated");
		}

		volume = 80;
		MAX_NPC_COUNT = 60;
	}

	public PackedScene getDriveScene
	{
		get { return driveScene; }
	}
	public PackedScene getOptionsScene
	{
		get { return optionsScene; }
	}
	public PackedScene getMainScene
	{
		get { return mainScene; }
	}
	public PackedScene getPauseScene
	{
		get { return pauseScene; }
	}
	public PackedScene getGameOverScene
	{
		get {return gameOverScene;}
	}
	public int getVolume
	{
		get {return volume;}

	}
	public int getMAX_NPC_COUNT
	{
		get {return MAX_NPC_COUNT;}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
