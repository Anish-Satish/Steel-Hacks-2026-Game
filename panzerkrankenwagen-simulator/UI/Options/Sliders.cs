using Godot;
using System;

public partial class Sliders : VBoxContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void on_sound_value_changed(float num)
	{
		Main.volume += (int)num;
	}
	public void on_npc_count_value_changed(float num)
	{
		Main.MAX_NPC_COUNT += (int)num;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
