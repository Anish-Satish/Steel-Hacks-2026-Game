using Godot;
using System;

public partial class Pedestrian : Node3D
{
	public bool IsHit = false;
	int speed = 1;
	Vector3 direction;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		directionSelecter();
	}
	private void directionSelecter()//Randomly Determines Pedestrian Direction
	{
		Random rnd= new Random();
		int range= 10;
		int randomInt=rnd.Next(1,9);
		direction = new Vector3(randomInt,0,range-randomInt);
	}
	private void MovePedestrian(double delta)
	{
		position= position + direction * speed*delta;
	}
	public void HitDead()
	{
		IsHit=true;
		//Add whatever else you want to happen when hit
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(IsHit==true)
		{
			
		}else
		{
			MovePedestrian(delta);	
		}
	}
}
