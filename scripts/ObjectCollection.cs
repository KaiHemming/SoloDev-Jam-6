using Godot;
using System;

public partial class ObjectCollection : Node
{
	Control UI;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		UI = (Control)GetParent().GetChild(0).GetChild(0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void _on_nutcracker_body_entered(Node2D body)
	{
		if (body is Player) {
			UI.Call("findItem", "Nutcracker");
			GetChild(0).QueueFree();
		}
	}


	private void _on_wreath_body_entered(Node2D body)
	{
		if (body is Player) {
			UI.Call("findItem", "Wreath");
			GetChild(1).QueueFree();
		}
	}


	private void _on_gnome_body_entered(Node2D body)
	{
		if (body is Player) {
			UI.Call("findItem", "Gnome");
			GetChild(2).QueueFree();
		}
	}
}
