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
		var floor_pos = (Vector2I)(globalPositionOffset/70).Floor();
		var ceil_pos = (Vector2I)(globalPositionOffset/70).Ceil();

		// Destroy tile
		SetCell(0, floor_pos, sourceId: -1, alternativeTile: -1);
		SetCell(0, ceil_pos, sourceId: -1, alternativeTile: -1);

		//Explosion particles
		Godot.Vector2 explositionPosition = globalPosition;
		explositionPosition.Y += 40;
		SnowExplosion explosion = (SnowExplosion)SnowExplosionScene.Instantiate();
		explosion.GlobalPosition = explositionPosition;
		GetParent().AddChild(explosion);

		//Play footstep
		var player = (AudioStreamPlayer)(GetParent().GetNode("Footstep1"));
		if (!player.Playing) player.Play();
	}
}
