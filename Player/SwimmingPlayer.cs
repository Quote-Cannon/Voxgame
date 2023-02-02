using Godot;
using System;

public class SwimmingPlayer : Player
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	Vector2 momentum = Vector2.Zero;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		_Update(delta);
		_Movement(delta);
	}
	
	protected override void _Movement(float delta)
	{
		GD.Print($"{momentum}");
		if (momentum != Vector2.Zero)
		{
			float x = momentum.x; float y = momentum.y;
			momentum.x = x > 0f ? Math.Max(0.0f, x - 8f) : Math.Min(0.0f, x + 8f);
			momentum.y = y > 0f ? Math.Max(0.0f, y - 8f) : Math.Min(0.0f, y + 8f);
		}
		else
			momentum = base._GetVelocity()*Speed;
		
		if (momentum.Length() > 0)
			animatedSprite.Animation = "walk";
		else
			animatedSprite.Animation = "idle";

		MoveAndSlide(momentum);
	}
}
