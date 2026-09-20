using Godot;
using System;

public partial class Timer : Godot.Timer
{
	// Called when the node enters the scene tree for the first time.
	Timer countdown;
	//how many times to loop timer
	int count = 0;
	float time = 0.0f;
	//text for timer
	Countdown c;
	public override void _Ready()
	{
		c = GetNode<Countdown>("../Countdown");
		Timeout += on_countdown_timeout;
	}

	public void setCountdownTime(float time, int count)
	{
		this.time = time;
		c.setCountdownText(count);
		countdown.Start(time);
		this.count = count;
		countdown.Connect("timeout", new Callable(this, "on_countdown_timeout"));
	}

	public void on_countdown_timeout()
	{
		countdown.Stop();
		Console.WriteLine(time.ToString() + "Second Countdown finished");
		if (count < 1)
		{
			timer_done();
		}
		else
		{
			count--;
			countdown.Start(time);
			c.setCountdownText(count);
		}

	}

	public int getCountdownTime()
	{
		return (int)countdown.TimeLeft;
	}

	private void timer_done()
	{
		countdown.Stop();
		Console.WriteLine("Attempting to Remove Countdown");
		GetTree().Root.RemoveChild(c);
		GetNode<GameClock>("GameClock").setCountdownTime(360, 360);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
