using Godot;
using System;

public partial class Joueur : Area2D
{

[Export]
private float SPEED = 400;
private AnimatedSprite2D animatedSprite2D;
private CollisionShape2D collisionShape2D;

private Vector2 velocity;
private Vector2 screenSize;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		screenSize = GetViewportRect().Size;
		animatedSprite2D = (AnimatedSprite2D)GetNode("AnimatedSprite2D");
		collisionShape2D = (CollisionShape2D)GetNode("CollisionShape2D");


	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		velocity = new Vector2();
		if(Input.IsActionPressed("ui_right"))
		{
			velocity.X += 1;
		}
		if(Input.IsActionPressed("ui_left"))
		{
			velocity.X -= 1;
		}
		if(Input.IsActionPressed("ui_down"))
		{
			velocity.Y += 1;
		}
		if(Input.IsActionPressed("ui_up"))
		{
			velocity.Y -= 1;
		}



		if(velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * SPEED;
			animatedSprite2D.Play();

		}else
		{
			animatedSprite2D.Stop();
		}

		Position += velocity * (float)delta;

		Position = new Vector2(
			Math.Clamp(Position.X, 0, screenSize.X),
			Math.Clamp(Position.Y, 0, screenSize.Y)

		);

		if(velocity.X != 0){
			animatedSprite2D.Animation = "droite";
			animatedSprite2D.FlipH = velocity.X < 0;
			animatedSprite2D.FlipV = false;
		}else if(velocity.Y != 0){
			animatedSprite2D.Animation = "haut";
			animatedSprite2D.FlipV = velocity.Y > 0;
		}
		
	}
}
