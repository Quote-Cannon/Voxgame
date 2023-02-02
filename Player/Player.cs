using Godot;
using System;

public class Player : KinematicBody2D
{
	// Declare member variables here. Examples:
	[Export]
	public int Speed = 400;
	public AnimatedSprite animatedSprite;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		animatedSprite.Play();
	}

// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		_Update(delta);
		_Movement(delta);
	}
	
	protected virtual void _Movement(float delta)
	{
		Vector2 velocity = _GetVelocity();

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite.Animation = "walk";
		}
		else
			animatedSprite.Animation = "idle";
			
		if (Input.IsActionPressed("run"))
			velocity *= 1.5f;
		
		if (velocity.x != 0)
			animatedSprite.FlipH = velocity.x < 0;
		
		MoveAndSlide(velocity);
	}
	
	protected virtual void _Update(float delta)
	{
		if (Input.IsActionJustPressed("fullscreen"))
			OS.WindowFullscreen = !OS.WindowFullscreen;
    }
	
	protected Vector2 _GetVelocity()
	{
		Vector2 velocity = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("move_right"))
			velocity.x += 1;
		if (Input.IsActionPressed("move_left"))
			velocity.x -= 1;
		if (Input.IsActionPressed("move_down"))
			velocity.y += 1;
		if (Input.IsActionPressed("move_up"))
			velocity.y -= 1;
		
		return velocity.Normalized();
	}
}
