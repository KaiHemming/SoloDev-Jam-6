using Godot;
using System;
using System.Numerics;

public partial class Snow : TileMap
{
	private PackedScene SnowExplosionScene = GD.Load<PackedScene>("res://scenes/SnowExplosion.tscn"); 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void DestroyTile(Godot.Vector2 globalPosition) {
		// Remove offset
		Godot.Vector2 globalPositionOffset = globalPosition;

		// globalPositionOffset.Y = globalPosition.Y - Position.Y;
		globalPositionOffset = globalPosition - Position;

		// Round and get tile
		var pos = (Vector2I)(globalPositionOffset/70).Round();
		GD.Print("Removing at " + pos + "global: " + globalPositionOffset);

		// Destroy tile
		SetCell(0, pos, sourceId: -1, alternativeTile: -1);

		//Explosion particles
		Godot.Vector2 explositionPosition = globalPosition;
		explositionPosition.Y += 40;
		SnowExplosion explosion = (SnowExplosion)SnowExplosionScene.Instantiate();
		explosion.GlobalPosition = explositionPosition;
		GD.Print("Adding explosion at " + explosion.GlobalPosition);
		GetParent().AddChild(explosion);
	}
}
