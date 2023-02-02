using Godot;
using System;

public class HidingSpot : Interactable
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    protected override void Interact()
    {
        player.SetPhysicsProcess(!player.IsPhysicsProcessing());
        player.Visible = !player.Visible;
    }
}
