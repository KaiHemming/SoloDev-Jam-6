using Godot;
using System;

public partial class Player : Godot.CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -950.0f;
	private AnimatedSprite2D _animatedSprite;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = 2000;

	private Boolean isJumping = true;
	private Boolean hasJumped = false;
	private Boolean isLanding = false;
	private Boolean hasDived  = false;
	private Boolean isDiving = false;
	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_animatedSprite.Play("idle");
	}


	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor()) {
			velocity.Y += gravity * (float)delta;
			if (isJumping) {
				if (!hasJumped) {
					hasJumped = true;
					_animatedSprite.Play("jump");
				}
			}
			if (isDiving) {
				if (!hasDived) {
					GD.Print("Play dive animation");
					hasDived = true;
					_animatedSprite.Play("dive");
				}
			}
		}
		else {
			if (isJumping) {
				isLanding = true;
				_animatedSprite.Play("land");
			}
			isJumping = false;
			hasJumped = false;
			hasDived = false;
			isDiving = false;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			if (!isJumping & !isLanding) {
				_animatedSprite.Play("walk");
			}
			_animatedSprite.FlipH = Velocity.X < 0;
			if (isDiving) {
				velocity.X = direction.X * Speed * 3;
			} else {
				velocity.X = direction.X * Speed;
			}
		}
		else
		{
			if (!isJumping & !isLanding) {
				_animatedSprite.Play("idle");
			}
			if (isDiving) {
				velocity.X = Velocity.X;
			} else {
				velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			}
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept")) {
			if (IsOnFloor()) {
				velocity.Y = JumpVelocity;
				isJumping = true;
			} else {
				if (direction != Vector2.Zero) {
					GD.Print("Instantiate dive");
					isDiving = true;
				}
			}
		}
		Velocity = velocity;
		MoveAndSlide();
	}
	private void _on_animated_sprite_2d_animation_finished()
	{
		if (!isJumping) {
			_animatedSprite.Play("idle");
			isLanding = false;
		}
	}
	private void _on_animated_sprite_2d_animation_looped()
	{
		if (_animatedSprite.Animation == "jump") {
			_animatedSprite.Pause();
		}
		if (_animatedSprite.Animation == "dive") {
			_animatedSprite.Pause();
		}
	}
}
