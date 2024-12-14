using Godot;
using System;

public partial class SnowExplosion : Node2D
{
	public override void _Ready()
	{
		((CpuParticles2D)this.GetChild(0)).Emitting = true;
		GD.Print("Readied snow explosion");
	}
	private void _on_cpu_particles_2d_finished()
	{
		QueueFree();
		GD.Print("Freed snow explosion particles");
	}
}
