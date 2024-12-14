using Godot;
using System;

public partial class ObjectCollection : Node
{
	Control UI;
	Area2D Nutcracker;
	Area2D Wreath;
	Area2D Gnome;
	Area2D Teddy;
	Area2D Stocking;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		UI = (Control)GetParent().GetChild(0).GetChild(0);
		Nutcracker = (Area2D)GetChild(0);
		Wreath = (Area2D)GetChild(1);
		Gnome = (Area2D)GetChild(2);
		Teddy = (Area2D)GetChild(3);
		Stocking = (Area2D)GetChild(4);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void _on_nutcracker_body_entered(Node2D body)
	{
		if (body is Player) {
			UI.Call("findItem", "Nutcracker");
			Nutcracker.QueueFree();
		}
	}


	private void _on_wreath_body_entered(Node2D body)
	{
		if (body is Player) {
			UI.Call("findItem", "Wreath");
			Wreath.QueueFree();
		}
	}


	private void _on_gnome_body_entered(Node2D body)
	{
		if (body is Player) {
			UI.Call("findItem", "Gnome");
			Gnome.QueueFree();
		}
	}

	private void _on_teddy_body_shape_entered(Rid body_rid, Node2D body, long body_shape_index, long local_shape_index)
	{
		if (body is Player) {
			UI.Call("findItem", "Teddy");
			Teddy.QueueFree();
		}
	}


	private void _on_stocking_body_shape_entered(Rid body_rid, Node2D body, long body_shape_index, long local_shape_index)
	{
		if (body is Player) {
			UI.Call("findItem", "Stocking");
			Stocking.QueueFree();
		}
	}
}
