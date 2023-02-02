using Godot;
using System;

public class Interactable : Node2D
{
    // Declare member variables here. Examples:
    protected Player player;
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        player = GetParent().GetNode<Player>("Player");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        float playerDistance = player.Position.DistanceSquaredTo(Position);
        if (playerDistance < 400)
            if (Input.IsActionJustPressed("interact"))
            {
                GD.Print("E");
                Interact();
            }
    }

    protected virtual void Interact()
    {

    }
}
